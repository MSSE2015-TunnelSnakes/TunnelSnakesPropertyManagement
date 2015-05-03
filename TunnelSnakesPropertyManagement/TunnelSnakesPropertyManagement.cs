using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace TunnelSnakesPropertyManagement
{
	public class App : Application
	{
		static DatabaseHelper database;

		public App ()
		{
			var mainNav = new NavigationPage (new HomePage ());
			MainPage = mainNav;
		}

		protected override void OnStart ()
		{
			var homePage = new HomePage ();
			MainPage.Navigation.PushAsync (homePage, false);
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