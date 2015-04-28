using System;
using Xamarin.Forms;

namespace TunnelSnakesPropertyManagement
{
	public class PaymentListCell : ViewCell
	{
		public PaymentListCell ()
		{
			var firstNameLabel = new Label {
				YAlign = TextAlignment.Center
			};
			firstNameLabel.SetBinding (Label.TextProperty, "first_name");

			var lastNameLabel = new Label {
				YAlign = TextAlignment.Center
			};
			lastNameLabel.SetBinding (Label.TextProperty, "last_name");

			var dueDateLabel = new Label {
				YAlign = TextAlignment.Center
			};
			dueDateLabel.SetBinding (Label.TextProperty, "due_date");

			var isPaidLabel = new Label {
				YAlign = TextAlignment.Center
			};
//			isPaidLabel.VerticalOptions.Alignment = LayoutAlignment.End;
//			isPaidLabel.HorizontalOptions.Alignment = LayoutAlignment.End;
			isPaidLabel.SetBinding (Label.TextProperty, "is_paid");

			var amountLabel = new Label {
				YAlign = TextAlignment.Center
			};
			//amountLabel.HorizontalOptions.Alignment = LayoutAlignment.End;
			amountLabel.SetBinding (Label.TextProperty, "amount");

			var layout = new StackLayout {
				Padding = new Thickness(40, 0, 0, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {firstNameLabel,  lastNameLabel}
			};
			View = layout;
		}

		protected override void OnBindingContextChanged ()
		{
			// Todo : this is happening because the View.Parent is getting 
			// set after the Cell gets the binding context set on it. Then it is inheriting
			// the parents binding context.
			View.BindingContext = BindingContext;
			base.OnBindingContextChanged ();
		}
	}
}

