using System;
using Xamarin.Forms;

namespace TunnelSnakesPropertyManagement
{
	public class TenantPage : ContentPage
	{
		Button deleteButton;
		Tenant tenant = null;

		public TenantPage ()
		{

			Title = "Tenant";

			var firstNameLabel = new Label {
				Text = "First Name"
			};

			var firstName = new Entry { Placeholder = "First Name", StyleId = "UserId" };
			firstName.SetBinding (Entry.TextProperty, "first_name");

			var lastNameLabel = new Label {
				Text = "Last Name"
			};

			var lastName = new Entry { Placeholder = "Last Name", StyleId = "UserId" };
			lastName.SetBinding (Entry.TextProperty, "last_name");

			var homePhoneLabel = new Label {
				Text = "Home Phone"
			};
			var homePhone = new Entry { Placeholder = "Home Phone", StyleId = "UserId" };
			homePhone.SetBinding (Entry.TextProperty, "phone_home");


			var cellPhoneLabel = new Label {
				Text = "Cell Phone"
			};
			var cellPhone = new Entry { Placeholder = "Cell Phone", StyleId = "UserId" };
			cellPhone.SetBinding (Entry.TextProperty, "phone_cell");

			var emailLabel = new Label {
				Text = "Email"
			};

			var email = new Entry { Placeholder = "Email", StyleId = "UserId" };
			email.SetBinding (Entry.TextProperty, "email");

			var leaseStartDateLabel = new Label {
				Text = "Lease Start Date"
			};

			var leaseStartDate = new Entry { Placeholder = "Lease Start Date", StyleId = "UserId" };
			leaseStartDate.SetBinding (Entry.TextProperty, "lease_start_date");

			var leaseEndDateLabel = new Label {
				Text = "Lease End Date"
			};
			var leaseEndDate = new Entry { Placeholder = "Lease End Date", StyleId = "UserId" };
			leaseEndDate.SetBinding (Entry.TextProperty, "lease_end_date");

			//BindingContext = Model;

			var saveButton = new Button { Text = "Save" };
			saveButton.Clicked  += (sender, args) =>
			{
				if (tenant == null) {
					tenant = new Tenant();
				}

				tenant.first_name = firstName.Text;
				tenant.last_name = lastName.Text;
				tenant.phone_home = homePhone.Text;
				tenant.phone_cell = cellPhone.Text;
				tenant.email = email.Text;
				tenant.lease_start_date = leaseStartDate.Text;
				tenant.lease_end_date = leaseEndDate.Text;

				DatabaseHelper dbHelper = new DatabaseHelper();
				dbHelper.SaveTenant(tenant);
				Navigation.PopAsync();
			};

			deleteButton = new Button { Text = "Delete" };
			deleteButton.Clicked  += (sender, args) =>
			{
				DatabaseHelper dbHelper = new DatabaseHelper();
				dbHelper.DeleteTenant(tenant.tenant_id);
				Navigation.PopAsync();
			};

			var grid = new Grid () {
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
					
			grid.Children.Add (firstNameLabel, 0, 0);
			grid.Children.Add (firstName, 1, 0);
			grid.Children.Add (lastNameLabel, 0, 1);
			grid.Children.Add (lastName, 1, 1);
			grid.Children.Add (homePhoneLabel, 0, 2);
			grid.Children.Add (homePhone, 1, 2);
			grid.Children.Add (cellPhoneLabel, 0, 3);
			grid.Children.Add (cellPhone, 1, 3);
			grid.Children.Add (emailLabel, 0, 4);
			grid.Children.Add (email, 1, 4);
			grid.Children.Add (leaseStartDateLabel, 0, 5);
			grid.Children.Add (leaseStartDate, 1, 5);
			grid.Children.Add (leaseEndDateLabel, 0, 6);
			grid.Children.Add (leaseEndDate, 1, 6);

			Content = new StackLayout () {
				VerticalOptions = LayoutOptions.Center,
				Padding = new Thickness (30),
				Children = { grid,  saveButton , deleteButton}
			};
		}

		protected override void OnAppearing()
		{            
			base.OnAppearing();

			tenant = BindingContext as Tenant;
			if (tenant == null || tenant.tenant_id <= 0) {
				if (deleteButton != null) {
					deleteButton.IsVisible = false;
				}
			}
		}
	}
}

