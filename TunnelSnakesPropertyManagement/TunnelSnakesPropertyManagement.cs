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

			Property testProp = new Property ();
			testProp.Address = "123 ABC Street";
			testProp.Capacity = 3;
			testProp.City = "Minneapolis";
			testProp.Zip = "55410";

			Database.SaveProperty (testProp);
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
	}
}

