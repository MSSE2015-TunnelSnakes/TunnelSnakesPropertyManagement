using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace TunnelSnakesPropertyManagement
{
	public class PropertyListPage : ContentPage
	{

		ListView listView;

		public PropertyListPage ()
		{
			//InitializeComponent ();
			Title = "Manage Properties";
			PopulateListView ();

		}

		private void PopulateListView() {
			var layout = new StackLayout();

			// Tenants 
			listView = new ListView ();
			listView.ItemTemplate = new DataTemplate (typeof (PropertyListCell));
			DatabaseHelper dbHelper = new DatabaseHelper();
			var properties = dbHelper.GetPropertyAddresses ();


			listView.ItemsSource = properties;
			listView.ItemTemplate = new DataTemplate(typeof(PropertyListCell));
			listView.ItemSelected += (sender, e) => {
				var property = (Property)e.SelectedItem;
				var propertyPage = new PropertyPage();
				propertyPage.BindingContext = property;
				Navigation.PushAsync(propertyPage);
			};

			layout.Children.Add(listView);
			int counter = 0;
			foreach (Property p in properties) {
				counter++;
			}

			Label temp = new Label {
				Text = String.Format("Total Properties: {0}", counter)
			};
			layout.Children.Add (temp);
			// END Tenants


			Button addNewProperty = new Button
			{
				Text = String.Format("Add New Property")
			};
			addNewProperty.Clicked += (sender, args) =>
			{
				PropertyPage propertyPage = new PropertyPage();
				this.Navigation.PushAsync(propertyPage);
			};

			layout.Children.Add(addNewProperty);

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

