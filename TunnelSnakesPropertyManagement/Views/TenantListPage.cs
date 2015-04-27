using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace TunnelSnakesPropertyManagement
{
	public class TenantListPage : ContentPage
	{

		ListView listView;

		public TenantListPage ()
		{
			//InitializeComponent ();
			Title = "Manage Tenants";
			PopulateListView ();

		}

		private void PopulateListView() {
			var layout = new StackLayout();

			// Tenants 
			listView = new ListView ();
			listView.ItemTemplate = new DataTemplate (typeof (TenantListCell));
			DatabaseHelper dbHelper = new DatabaseHelper();
			var tenants = (ObservableCollection<Tenant>) dbHelper.GetAllTenants();


			listView.ItemsSource = tenants;
			listView.ItemTemplate = new DataTemplate(typeof(TenantListCell));
			//listView.ItemTemplate.SetBinding(TextCell.TextProperty, "last_name");

			listView.ItemSelected += (sender, e) => {
				var tenant = (Tenant)e.SelectedItem;
				var tenantPage = new TenantPage();
				tenantPage.BindingContext = tenant;

				//	((App)App.Current).ResumeAtTodoId = tenant.tenant_id;
				//Debug.WriteLine("setting ResumeAtTodoId = " + todoItem.ID);

				Navigation.PushAsync(tenantPage);
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
				TenantPage addEditTenantPage = new TenantPage();
				this.Navigation.PushAsync(addEditTenantPage);
			};

			layout.Children.Add(addNewTenant);

			layout.VerticalOptions = LayoutOptions.FillAndExpand;
			Content = layout;
		}

		protected override void OnAppearing()
		{            
			base.OnAppearing ();
			PopulateListView ();
		}
	}
}

