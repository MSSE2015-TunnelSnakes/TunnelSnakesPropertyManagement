using System;
using Xamarin.Forms;
using System.Collections.Generic;


namespace TunnelSnakesPropertyManagement
{
	public class TenantListPage : ContentPage
	{

		ListView listView;

		public TenantListPage ()
		{
			//InitializeComponent ();
			Title = "Tenants";

			var layout = new StackLayout();

			//listView.ItemSelected += (sender, e) => {
			//				var todoPage = new TodoItemPage();
			//				Navigation.PushAsync(todoPage);
			//			};
			Label homeLabel = new Label {
				Text = "Manage Tenants"
			};
			layout.Children.Add (homeLabel);


			// Tenants 
			listView = new ListView ();
			listView.ItemTemplate = new DataTemplate (typeof (TenantListCell));
			DatabaseHelper helper = new DatabaseHelper();
			List<Tenant> tenants = new List<Tenant> ();
		//	ArrayList<Tenant> tenants = (ArrayList<Tenant>) helper.GetAllTenants();
			this.BindingContext = helper.GetAllTenants();
		//	TunnelSnakesPropertyManagment.Database.getAllTenants();
			listView.ItemSelected += (sender, e) => {
				var tenant = (Tenant)e.SelectedItem;
				//var todoPage = new TodoItemPage();
				//todoPage.BindingContext = todoItem;

			//	((App)App.Current).ResumeAtTodoId = tenant.tenant_id;
				//Debug.WriteLine("setting ResumeAtTodoId = " + todoItem.ID);

			//	Navigation.PushAsync(todoPage);
			};

			layout.Children.Add(listView);
			int counter = 0;
			foreach (Tenant t in tenants) {
				counter++;
			}

			Label temp = new Label {
				Text = String.Format("Total Tenants: {0}", counter)
			};
			layout.Children.Add (temp);
			// END Tenants


			Button addNewTenant = new Button
			{
				Text = String.Format("Add New Tenant")
			};
			addNewTenant.Clicked += (sender, args) =>
			{
				AddEditTenantPage addEditTenantPage = new AddEditTenantPage();
				this.Navigation.PushAsync(addEditTenantPage);
			};
				
			layout.Children.Add(addNewTenant);

			layout.VerticalOptions = LayoutOptions.FillAndExpand;
			Content = layout;

		} 
	}
}

