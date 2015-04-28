using System;
using Xamarin.Forms;

namespace TunnelSnakesPropertyManagement
{
	public class PropertyPage : ContentPage
	{
		Button deleteButton;
		Property property = null;

		public PropertyPage ()
		{

			Title = "Property";

			var addressLabel = new Label {
				Text = "Address"
			};

			var address = new Entry { Placeholder = "Address", StyleId = "UserId" };
			address.SetBinding (Entry.TextProperty, "address_id");

			var numBedroomsLabel = new Label {
				Text = "Number of Bedrooms: "
			};

			var numBedrooms = new Entry { Placeholder = "Bedrooms", StyleId = "UserId" };
			numBedrooms.SetBinding (Entry.TextProperty, "num_bedrooms");

			var numBathroomsLabel = new Label {
				Text = "Number of Bathrooms"
			};
			var numBathrooms = new Entry { Placeholder = "Bathrooms", StyleId = "UserId" };
			numBathrooms.SetBinding (Entry.TextProperty, "num_bathrooms");

			var canMixTenantsLabel = new Label {
				Text = "Can Mix Tenants?"
			};

			var canMixTenants = new Entry { Placeholder = "Mix Tenants", StyleId = "UserId" };
			canMixTenants.SetBinding (Entry.TextProperty, "can_mix_tenants");

			//BindingContext = Model;

			var saveButton = new Button { Text = "Save" };
			saveButton.Clicked  += (sender, args) =>
			{
				if (property == null) {
					property = new Property();
				}

				property.address_id = Convert.ToInt32(address.Text);
				property.num_bathrooms =  Convert.ToInt32(numBathrooms.Text);
				property.num_bedrooms =  Convert.ToInt32(numBedrooms.Text);
				property.can_mix_tenants =  Convert.ToInt32(canMixTenants.Text);

				DatabaseHelper dbHelper = new DatabaseHelper();
				dbHelper.SaveProperty(property);
				Navigation.PopAsync();
			};

			deleteButton = new Button { Text = "Delete" };
			deleteButton.Clicked  += (sender, args) =>
			{
				DatabaseHelper dbHelper = new DatabaseHelper();
				dbHelper.DeleteProperty(property.property_id);
				Navigation.PopAsync();
			};

			var grid = new Grid () {
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
					
			grid.Children.Add (addressLabel, 0, 0);
			grid.Children.Add (address, 1, 0);
			grid.Children.Add (numBedroomsLabel, 0, 1);
			grid.Children.Add (numBedrooms, 1, 1);
			grid.Children.Add (numBathroomsLabel, 0, 2);
			grid.Children.Add (numBathrooms, 1, 2);
			grid.Children.Add (canMixTenantsLabel, 0, 3);
			grid.Children.Add (canMixTenants, 1, 3);

			Content = new StackLayout () {
				VerticalOptions = LayoutOptions.Center,
				Padding = new Thickness (30),
				Children = { grid,  saveButton , deleteButton}
			};
		}

		protected override void OnAppearing()
		{            
			base.OnAppearing();

			property = BindingContext as Property;
			if (property == null || property.property_id <= 0) {
				if (deleteButton != null) {
					deleteButton.IsVisible = false;
				}
			}
		}
	}
}

