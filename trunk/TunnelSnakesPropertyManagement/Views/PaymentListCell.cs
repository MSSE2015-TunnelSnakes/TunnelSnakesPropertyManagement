using System;
using Xamarin.Forms;

namespace TunnelSnakesPropertyManagement
{
	public class PaymentListCell : ViewCell
	{
		public PaymentListCell ()
		{
			var tenantLabel = new Label {
			};
			tenantLabel.SetBinding (Label.TextProperty, "TenantName");
			var dueDateLabel = new Label {
				YAlign = TextAlignment.Center
			};

			dueDateLabel.SetBinding (Label.TextProperty, "DueDateString");

			var amountDueLabel = new Label {
				YAlign = TextAlignment.End,
				XAlign = TextAlignment.End					
			};
			amountDueLabel.SetBinding (Label.TextProperty, "PaymentDueString");

			var layout = new StackLayout {
				Padding = new Thickness(20, 0, 0, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = { tenantLabel, dueDateLabel, amountDueLabel }
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

