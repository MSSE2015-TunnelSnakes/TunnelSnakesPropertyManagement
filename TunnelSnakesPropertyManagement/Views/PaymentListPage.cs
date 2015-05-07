using System;
using Xamarin.Forms;
using System.Linq;

namespace TunnelSnakesPropertyManagement
{
	public class PaymentListPage : ContentPage
	{
		ListView listView;

		public PaymentListPage ()
		{
			//InitializeComponent ();
			Title = "Payment List";
			PopulateListView ();
		}

		private void PopulateListView() {
			var layout = new StackLayout();

			// Tenants 
			listView = new ListView ();
			listView.ItemTemplate = new DataTemplate (typeof (PaymentListCell));
			DatabaseHelper dbHelper = new DatabaseHelper();
			//todo: add date pickers?
			var after = DateTime.Now.AddDays (-15);
			var before = DateTime.Now.AddDays (30);
			var payments = dbHelper.GetPayments (after, before);

			listView.ItemsSource = payments;
			listView.ItemTemplate = new DataTemplate(typeof(PaymentListCell));
			listView.ItemSelected += (sender, e) => {
				var payment = (Payment)e.SelectedItem;
				var paymentPage = new PaymentPage();
				paymentPage.BindingContext = payment;
				Navigation.PushAsync(paymentPage);
			};

			layout.Children.Add(listView);
			int counter = payments.Count();

			Label temp = new Label {
				Text = String.Format("Total Payments {0}-{1}: {2}", 
					after.ToString("M/d/yyyy"), before.ToString("M/d/yyyy"), counter)
			};
			layout.Children.Add (temp);
			// END Payments

			Button addNewPayment = new Button
			{
				Text = String.Format("Add New Payment")
			};
			addNewPayment.Clicked += (sender, args) =>
			{
				PaymentPage paymentPage = new PaymentPage();
				this.Navigation.PushAsync(paymentPage);
			};

			layout.Children.Add(addNewPayment);

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


