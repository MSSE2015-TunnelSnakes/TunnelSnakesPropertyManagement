using System;
using Xamarin.Forms;
using TunnelSnakesPropertyManagement;

namespace TunnelSnakesPropertyManagement
{
	public class HomePage : ContentPage
	{
		public HomePage ()
		{
			//InitializeComponent ();
			Title = "Home";

			var layout = new StackLayout();

			Button manageTenants = new Button
			{
				Text = String.Format("Manage Tenants")
			};
			manageTenants.Clicked += (sender, args) =>
			{
				TenantListPage tenantListPage = new TenantListPage();
				this.Navigation.PushAsync(tenantListPage);
			};

			var count = 0;

			Button viewPayments = new Button
			{
				Text = String.Format("View Payment Calendar")
			};
			viewPayments.Clicked += (sender, args) =>
			{
				viewPayments.Text = String.Format("{0} click{1}!", count, count == 1 ? "" : "s");
			};


			Button manageProperties = new Button
			{
				Text = String.Format("Manage Properties")
			};
			manageProperties.Clicked += (sender, args) =>
			{
				manageProperties.Text = String.Format("{0} click{1}!", count, count == 1 ? "" : "s");
			};


			Button messageTenants = new Button
			{
				Text = String.Format("Message Tenants")
			};
			messageTenants.Clicked += (sender, args) =>
			{
				messageTenants.Text = String.Format("{0} click{1}!", count, count == 1 ? "" : "s");
			};

			layout.Children.Add(manageTenants);
			layout.Children.Add(viewPayments);
			layout.Children.Add(manageProperties);
			layout.Children.Add(messageTenants);

			// START DEBUG
			/*
			Button debugBtn = new Button
			{
				Text = String.Format("Inject Contact")
			};
			debugBtn.Clicked += (sender, args) =>
			{
				DatabaseHelper dbHelper = new DatabaseHelper();
				Tenant tenant = new Tenant();
				tenant.first_name = "John";
				tenant.last_name = "User";
				tenant.phone_home = "123-555-2342";
				tenant.phone_cell = "123-555-3541";
				tenant.email = "JohnUser@Hotmail.com";
				tenant.least_start_date = "4/1/2015";
				tenant.least_end_date = "4/1/2016";
				dbHelper.SaveTenant(tenant);
				debugBtn.Text = String.Format("Contact Injected");
			};
			layout.Children.Add (debugBtn);
			*/
			// END DEBUG

			layout.VerticalOptions = LayoutOptions.FillAndExpand;
			Content = layout;
		}
	}
}