using System;
using Xamarin.Forms;

namespace TunnelSnakesPropertyManagement
{
	public class PropertyListCell : ViewCell
	{
		public PropertyListCell ()
		{
			var addressLabel = new Label {
				YAlign = TextAlignment.Center
			};
			addressLabel.SetBinding (Label.TextProperty, "property_id");

			var layout = new StackLayout {
				Padding = new Thickness(20, 0, 0, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {addressLabel}
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

