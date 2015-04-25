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
			int count = 0;

			var layout = new StackLayout();

			//listView.ItemSelected += (sender, e) => {
			//				var todoPage = new TodoItemPage();
			//				Navigation.PushAsync(todoPage);
			//			};

			/*
			Label homeLabel = new Label {
				Text = "Home",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				FontAttributes = FontAttributes.Bold
			};


			layout.Children.Add (homeLabel);
			*/

			Button manageTenants = new Button
			{
				Text = String.Format("Manage Tenants")
			};
			manageTenants.Clicked += (sender, args) =>
			{
				TenantListPage tenantListPage = new TenantListPage();
				this.Navigation.PushAsync(tenantListPage);
			};



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

			layout.VerticalOptions = LayoutOptions.FillAndExpand;
			Content = layout;
		}
	}
}