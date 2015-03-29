using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace TunnelSnakesPropertyManagement
{
	public class App : Application
	{
		static DatabaseHelper database;
		Label debugLabel;


		public App ()
		{
			debugLabel = new Label () {
				Text = "in progress..",
				XAlign = TextAlignment.Center
			};

			// The root page of your application
			MainPage = new ContentPage {


				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "The Tunnle Snakes Present... PROPERTY MANAGEMENT 2015!!!"
						}, 
						debugLabel
					}
				}
			};
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
			Debug.WriteLine ("The application has started");

			createDemoData ();
			var properties = Database.GetProperties ().GetEnumerator ();

			int count = 0;
			do
			{
				Property current = properties.Current;
				if (current != null ) {
					count++;
				}
			} while (properties.MoveNext());

			Debug.WriteLine ("Current Properties: " + count);
			debugLabel.Text = "Current Properties: " + count;
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

		public static DatabaseHelper Database {
			get { 
				if (database == null) {
					database = new DatabaseHelper ();
				}
				return database; 
			}
		}

		private void createDemoData() {
			Address addr1 = new Address ();
			addr1.address_line_1 = "123 Main Street";
			addr1.address_line_2 = "Appartment #330";
			addr1.city = "Minneapolis";
			addr1.state = "MN";
			addr1.zip = "55410";

			int addr1Id = Database.SaveAddress (addr1);

			Address addr2 = new Address ();
			addr2.address_line_1 = "123 Main Street";
			addr2.address_line_2 = "Appartment #330";
			addr2.city = "Minneapolis";
			addr2.state = "MN";
			addr2.zip = "55410";

			int addr2Id = Database.SaveAddress (addr2);

			Property prop1 = new Property ();
			prop1.address_id = addr2Id;
			prop1.can_mix_tenants = 0;
			prop1.num_bathrooms = 2;
			prop1.num_bedrooms = 3;

			int prop1Id = Database.SaveProperty (prop1);

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

			int tenant1Id = Database.SaveTenant (tenant1);


		}
	}
}

