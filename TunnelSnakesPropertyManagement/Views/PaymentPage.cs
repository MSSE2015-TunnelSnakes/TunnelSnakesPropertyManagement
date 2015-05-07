using System;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;

namespace TunnelSnakesPropertyManagement
{
	public class PaymentPage : ContentPage
	{
		Button deleteButton;
		Payment payment = null;
		Picker tenant;
		Picker property;
		Dictionary<string, int> tenants;
		Dictionary<string, int> addresses;
		Dictionary<string, int> properties;

		public PaymentPage ()
		{
			var db = new DatabaseHelper ();
			Title = "Payment";

			addresses = db.GetAddresses ().ToDictionary (x => x.address_id, y => y.AddressString);
			if (!addresses.Any ())
				throw new ArgumentException ("can't make a payment without an address");

			var props = db.GetProperties ();
			properties = new Dictionary<string, int> ();
			foreach(var prop in props)
			{
				if (!properties.ContainsKey (addresses [prop.address_id]))
					properties.Add (addresses [prop.address_id], prop.property_id);
			}

			if (!properties.Any ())
				throw new ArgumentException ("can't make a payment without a property");

			property = new Picker { Title = "Property", VerticalOptions = LayoutOptions.Start };

			foreach (string address in properties.Keys)
			{
				property.Items.Add(address);
			}

			int propertyId = properties.First().Value;
			property.SelectedIndexChanged += (sender, args) =>
			{
				var addressLine = property.Items[property.SelectedIndex];
				propertyId = properties[addressLine];
			};


			tenants = db.GetAllTenants ().ToDictionary (x => x.Name, x => x.tenant_id);
			if(!tenants.Any()) 
				throw new ArgumentException ("can't make a payment without a tenant");

			tenant = new Picker { Title = "Tenant", VerticalOptions = LayoutOptions.Start };

			foreach (string t in tenants.Keys)
			{
				tenant.Items.Add(t);
			}

			int tenantId = tenants.First().Value;
			tenant.SelectedIndexChanged += (sender, args) =>
			{
				var tenantLine = tenant.Items[property.SelectedIndex];
				tenantId = tenants[tenantLine];
			};

			DatePicker dueDate = new DatePicker
			{
				Format = "D",
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			dueDate.SetBinding (DatePicker.DateProperty, "due_date");

			var amountDueLabel = new Label {
				Text = "Amount Due"
			};
			Entry amountDue = new Entry
			{
				Placeholder = "Amount Due",
				VerticalOptions = LayoutOptions.Start
			};
			amountDue.SetBinding (Entry.TextProperty, "amount_due");

			var amountPaidLabel = new Label {
				Text = "Amount Paid"
			};
			Entry amountPaid = new Entry
			{
				Placeholder = "Amount Paid",
				VerticalOptions = LayoutOptions.Start
			};
			amountPaid.SetBinding (Entry.TextProperty, "amount_paid");

			var saveButton = new Button { Text = "Save" };
			saveButton.Clicked  += (sender, args) =>
			{
				if (payment == null) {
					payment = new Payment();
				}

				payment.property_id = propertyId;
				payment.tenant_id = tenantId;
				payment.due_date = dueDate.Date;

				try { payment.amount_due = Convert.ToDecimal(amountDue.Text);
				} catch(Exception ex) { payment.amount_due = 0M; }

				try { payment.amount_paid = Convert.ToDecimal(amountPaid.Text); 
				} catch(Exception ex) { payment.amount_paid = 0M; }

				DatabaseHelper dbHelper = new DatabaseHelper();
				var id = dbHelper.SavePayment(payment);
				Navigation.PopAsync();
			};

			deleteButton = new Button { Text = "Delete" };
			deleteButton.Clicked  += (sender, args) =>
			{
				DatabaseHelper dbHelper = new DatabaseHelper();
				dbHelper.DeletePayment(payment.payment_id);
				Navigation.PopAsync();
			};

			this.Content = new StackLayout
			{
				Padding = new Thickness(10),
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children =
				{
					property,
					tenant,
					dueDate,
					amountDueLabel,
					amountDue,
					amountPaidLabel,
					amountPaid,
					saveButton,
					deleteButton
				}
				};
		}

		protected override void OnAppearing()
		{            
			base.OnAppearing();

			payment = BindingContext as Payment;
			if (payment == null || payment.payment_id <= 0) {
				if (deleteButton != null) {
					deleteButton.IsVisible = false;
				}
			} else {

				var propertyString = properties.First (x => x.Value == payment.property_id).Key;
				property.SelectedIndex = property.Items.IndexOf (propertyString);

				var tenantString = tenants.First (x => x.Value == payment.tenant_id).Key;
				tenant.SelectedIndex = tenant.Items.IndexOf (tenantString);
			}
		}
	}
}

