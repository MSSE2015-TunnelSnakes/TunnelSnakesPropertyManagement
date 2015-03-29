using System;
using Xamarin.Forms;

namespace TunnelSnakesPropertyManagement
{
	public class TenantListCell : ViewCell
	{
		public TenantListCell ()
		{
			var firstNameLabel = new Label {
				YAlign = TextAlignment.Center
			};
			firstNameLabel.SetBinding (Label.TextProperty, "firstName");

			var lastNameLabel = new Label {
				YAlign = TextAlignment.Center
			};
			lastNameLabel.SetBinding (Label.TextProperty, "lastName");

			var layout = new StackLayout {
				Padding = new Thickness(20, 0, 0, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {firstNameLabel,  lastNameLabel}
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

