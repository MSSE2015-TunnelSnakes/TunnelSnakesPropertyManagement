using System;
using Xamarin.Forms;

namespace TunnelSnakesPropertyManagement
{
	public class SettingsPage : ContentPage
	{
		Button deleteButton;
		Button populateDataButton;

		public SettingsPage ()
		{

			Title = "Settings";

			//BindingContext = Model;

			populateDataButton = new Button { Text = "Populate Data" };
			populateDataButton.Clicked  += async(sender, args) =>
			{
				var answer = await DisplayAlert ("Populate Data?", "Inject Demo Data into Database?", "Yes", "No");
				if (answer) {
					createDemoData();
					DisplayAlert ("Data Populate", "Data Populated", "OK");
				}

			};

			deleteButton = new Button { Text = "Delete All Data" };

			deleteButton.Clicked  += async(sender, args) =>
			{
				var answer = await DisplayAlert ("Delete Data?", "Are you sure you want to delete ALL data?", "Yes", "No");
				if (answer) {
					DatabaseHelper dbHelper = new DatabaseHelper();
					dbHelper.DropTables();
					DisplayAlert ("Data Delete", "All Data Deleted", "OK");
				}
					
			};

			Content = new StackLayout () {
				VerticalOptions = LayoutOptions.Center,
				Padding = new Thickness (30),
				Children = {populateDataButton, deleteButton}
			};
		}

		protected override void OnAppearing()
		{            
			base.OnAppearing();
		}

		private void createDemoData() {
			DatabaseHelper dbHelper = new DatabaseHelper();

			Address addr1 = new Address ();
			addr1.address_line_1 = "123 Main Street";
			addr1.address_line_2 = "Appartment #330";
			addr1.city = "Minneapolis";
			addr1.state = "MN";
			addr1.zip = "55410";

			int addr1Id = dbHelper.SaveAddress (addr1);

			Address addr2 = new Address ();
			addr2.address_line_1 = "123 Main Street";
			addr2.address_line_2 = "Appartment #330";
			addr2.city = "Minneapolis";
			addr2.state = "MN";
			addr2.zip = "55410";

			int addr2Id = dbHelper.SaveAddress (addr2);

			Property prop1 = new Property ();
			prop1.address_id = addr2Id;
			prop1.can_mix_tenants = 0;
			prop1.num_bathrooms = 2;
			prop1.num_bedrooms = 3;

			int prop1Id = dbHelper.SaveProperty (prop1);

			Tenant tenant1 = new Tenant ();
			tenant1.property_id = prop1Id;
			tenant1.address_id = addr1Id;
			tenant1.first_name = "Bill";
			tenant1.last_name = "Anderson";
			tenant1.email = "banderson@hotmail.com";
			tenant1.phone_cell = "612-555-1010";
			tenant1.phone_home = "612-555-4545";
			tenant1.least_start_date = "4/1/2015";
			tenant1.least_end_date = "4/1/2016";

			dbHelper.SaveTenant (tenant1);

			Tenant tenant2 = new Tenant();
			tenant1.property_id = prop1Id;
			tenant1.address_id = addr2Id;
			tenant2.first_name = "John";
			tenant2.last_name = "User";
			tenant2.phone_home = "123-555-2342";
			tenant2.phone_cell = "123-555-3541";
			tenant2.email = "JohnUser@Hotmail.com";
			tenant2.least_start_date = "4/1/2015";
			tenant2.least_end_date = "4/1/2016";

			dbHelper.SaveTenant (tenant2);
		}
	}
}

