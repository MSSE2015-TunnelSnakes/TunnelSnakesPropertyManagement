using System;
using Xamarin.Forms;

namespace TunnelSnakesPropertyManagement
{
	public class PropertyListCell : ViewCell
	{
		public PropertyListCell ()
		{
			var address1Label = new Label {
				YAlign = TextAlignment.Center,
			};
			address1Label.SetBinding (Label.TextProperty, "address.address_line_1");

			var address2Label = new Label {
				YAlign = TextAlignment.Center,
			};
			address2Label.SetBinding (Label.TextProperty, "address.address_line_2");

			var cityLable = new Label {
				YAlign = TextAlignment.Center,
			};
			cityLable.SetBinding (Label.TextProperty, "address.city");

			var stateLabel = new Label {
				YAlign = TextAlignment.Center,
			};
			stateLabel.SetBinding (Label.TextProperty, "address.state");

			var zipLable = new Label {
				YAlign = TextAlignment.Center,
			};
			zipLable.SetBinding (Label.TextProperty, "address.zip");

			var layout = new StackLayout {
				Padding = new Thickness(20, 0, 0, 0),
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {address1Label, address2Label,  cityLable, stateLabel, zipLable}
			};
			View = layout;
		}

		protected override void OnBindingContextChanged ()
		{
			// Fixme : this is happening because the View.Parent is getting 
			// set after the Cell gets the binding context set on it. Then it is inheriting
			// the parents binding context.
			View.BindingContext = BindingContext;
			base.OnBindingContextChanged ();
		}
	}
}

