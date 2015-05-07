using System;
using Xamarin.Forms;

namespace TunnelSnakesPropertyManagement
{
	public class PropertyPage : ContentPage
	{
		Button deleteButton;
		PropertyAddress propertyAddress = null;

		public PropertyPage ()
		{

			Title = "Property";

			var address1Label = new Label {
				Text = "Address 1"
			};
			var address1 = new Entry { Placeholder = "Address", StyleId = "UserId" };
			address1.SetBinding (Entry.TextProperty, "address.address_line_1");

			var address2Label = new Label {
				Text = "Address 2"
			};
			var address2 = new Entry { Placeholder = "Address 2", StyleId = "UserId" };
			address2.SetBinding (Entry.TextProperty, "address.address_line_2");

			var cityLabel = new Label {
				Text = "City"
			};
			var city = new Entry { Placeholder = "City", StyleId = "UserId" };
			city.SetBinding (Entry.TextProperty, "address.city");

			var stateLabel = new Label {
				Text = "State"
			};
			var state = new Entry { Placeholder = "State", StyleId = "UserId" };
			state.SetBinding (Entry.TextProperty, "address.state");

			var zipLabel = new Label {
				Text = "Zip"
			};
			var zip = new Entry { Placeholder = "Zip", StyleId = "UserId" };
			zip.SetBinding (Entry.TextProperty, "address.zip");

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

				if (propertyAddress == null) {
					propertyAddress = new PropertyAddress();
				}

				if (propertyAddress.property_id > 0) {
					propertyAddress.address_id = Convert.ToInt32(propertyAddress.address_id);
				}

				propertyAddress.address.address_line_1 = address1.Text;
				propertyAddress.address.address_line_2 = address2.Text;
				propertyAddress.address.city = city.Text;
				propertyAddress.address.state = state.Text;
				propertyAddress.address.zip = zip.Text;

				propertyAddress.address_id = propertyAddress.address_id;
				propertyAddress.num_bathrooms =  Convert.ToInt32(numBathrooms.Text);
				propertyAddress.num_bedrooms =  Convert.ToInt32(numBedrooms.Text);
				propertyAddress.can_mix_tenants =  Convert.ToInt32(canMixTenants.Text);

				DatabaseHelper dbHelper = new DatabaseHelper();
				dbHelper.SavePropertyAddress(propertyAddress);
				Navigation.PopAsync();
			};

			deleteButton = new Button { Text = "Delete" };
			deleteButton.Clicked  += (sender, args) =>
			{
				DatabaseHelper dbHelper = new DatabaseHelper();
				dbHelper.DeleteProperty(propertyAddress.property_id);
				Navigation.PopAsync();
			};

			var grid = new Grid () {
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
					
			grid.Children.Add (address1Label, 0, 0);
			grid.Children.Add (address1, 1, 0);
			grid.Children.Add (address2Label, 0, 1);
			grid.Children.Add (address2, 1, 1);
			grid.Children.Add (cityLabel, 0, 2);
			grid.Children.Add (city, 1, 2);
			grid.Children.Add (stateLabel, 0, 3);
			grid.Children.Add (state, 1, 3);
			grid.Children.Add (zipLabel, 0, 4);
			grid.Children.Add (zip, 1, 4);
			grid.Children.Add (numBedroomsLabel, 0, 5);
			grid.Children.Add (numBedrooms, 1, 5);
			grid.Children.Add (numBathroomsLabel, 0, 6);
			grid.Children.Add (numBathrooms, 1, 6);
			grid.Children.Add (canMixTenantsLabel, 0, 7);
			grid.Children.Add (canMixTenants, 1, 7);

			Content = new StackLayout () {
				VerticalOptions = LayoutOptions.Center,
				Padding = new Thickness (30),
				Children = { grid,  saveButton , deleteButton}
			};
		}

		protected override void OnAppearing()
		{            
			base.OnAppearing();

			propertyAddress = BindingContext as PropertyAddress;
			if (propertyAddress == null || propertyAddress.property_id <= 0) {
				if (deleteButton != null) {
					deleteButton.IsVisible = false;
				}
			}
		}
	}
}

