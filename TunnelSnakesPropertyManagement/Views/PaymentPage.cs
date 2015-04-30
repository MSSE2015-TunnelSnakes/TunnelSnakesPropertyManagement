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
		Dictionary<string, int> properties;
		Dictionary<string, int> tenants;
		Picker property;
		Picker tenant;

		public PaymentPage ()
		{
			var db = new DatabaseHelper ();
			Title = "Payment";
			var isExisting = payment != null && payment.payment_id != null && payment.payment_id > 0;

			var addresses = db.GetAddresses ().ToDictionary (x => x.address_id, y => y.address_id + ". " + y.address_line_1 + " " + y.address_line_2);
			if (!addresses.Any ())
				throw new ArgumentException ("can't make a payment without an address");
			
			var props = db.GetProperties ();
			properties = new Dictionary<string, int> ();
			foreach(var prop in props)
			{
				if (!properties.ContainsKey (addresses [prop.address_id]))
					properties.Add (addresses [prop.address_id], prop.property_id);
			}
			//var properties = props.ToDictionary (x => addresses[x.address_id], y => y.property_id);
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

			tenants = db.GetAllTenants ().ToDictionary (x => x.tenant_id + ". " + x.first_name + " " + x.last_name, x => x.tenant_id);
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

			Entry amountDue = new Entry
			{
				Placeholder = "Amount Due",
				VerticalOptions = LayoutOptions.Start
			};
			amountDue.SetBinding (Entry.TextProperty, "amount_due");

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
				payment.amount_due = Convert.ToDecimal(amountDue.Text);
				payment.amount_paid = Convert.ToDecimal(amountPaid.Text);

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
					amountDue,
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
			var isExisting = true;
			if (payment == null || payment.payment_id <= 0) {
				if (deleteButton != null) {
					deleteButton.IsVisible = false;
				}
				isExisting = false;
			}

			if (isExisting) {
				var addressString = properties.First (x => x.Value == payment.property_id).Key;
				property.SelectedIndex = property.Items.IndexOf (addressString);
			}

			if (isExisting) {
				tenant.SelectedIndex = tenant.Items.IndexOf (tenants.First (x => x.Value == payment.tenant_id).Key); 
			}
		}
	}
}

