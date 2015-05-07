using System;
using Xamarin.Forms;
using TunnelSnakesPropertyManagement;

namespace TunnelSnakesPropertyManagement
{
	public class HomePage : ContentPage
	{
		public HomePage ()
		{
			NavigationPage.SetHasBackButton (this, false);
			//InitializeComponent ();
			Title = "Home";
			Icon = "trogdor.png";

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
				Text = String.Format("View Payments")
			};
			viewPayments.Clicked += (sender, args) =>
			{
				PaymentListPage paymentListPage = new PaymentListPage();
				this.Navigation.PushAsync(paymentListPage);
			};


			Button manageProperties = new Button
			{
				Text = String.Format("Manage Properties")
			};
			manageProperties.Clicked += (sender, args) =>
			{
				PropertyListPage propertyListPage = new PropertyListPage();
				this.Navigation.PushAsync(propertyListPage);
			};


			Button messageTenants = new Button
			{
				Text = String.Format("Message Tenants")
			};
			messageTenants.Clicked += (sender, args) =>
			{
				messageTenants.Text = "Not Yet Implemented";//String.Format("{0} click{1}!", count, count == 1 ? "" : "s");
			};

			Button settings = new Button
			{
				Text = String.Format("Settings")
			};
			settings.Clicked += (sender, args) =>
			{
				SettingsPage settingsPage = new SettingsPage();
				this.Navigation.PushAsync(settingsPage);
			};

			layout.Children.Add(manageTenants);
			layout.Children.Add(viewPayments);
			layout.Children.Add(manageProperties);
			layout.Children.Add(messageTenants);
			layout.Children.Add(settings);

			layout.VerticalOptions = LayoutOptions.FillAndExpand;
			Content = layout;
		}
	}
}