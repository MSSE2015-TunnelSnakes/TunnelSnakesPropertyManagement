using System;
using SQLite.Net.Attributes;

namespace TunnelSnakesPropertyManagement
{
	public class Payment
	{
		[PrimaryKey, AutoIncrement]
		public int payment_id { get; set; }
		public int property_id { get; set; }
		public int tenant_id { get; set; }
		public DateTime due_date { get; set; }
		public decimal amount_due { get; set; }
		public decimal amount_paid { get; set; }

		[Ignore]
		public bool IsPaid
		{
			get 
			{
				return amount_paid >= amount_due;
			}
		}

		[Ignore]
		public string PaymentDueString
		{
			get 
			{
				return IsPaid ? "[PAID]" : string.Format ("{0:C}", amount_due - amount_paid);
			}
		}

		[Ignore]
		public string TenantName { get; set; }

		[Ignore]
		public string DueDateString
		{
			get { return "Due Date: " + due_date.ToString ("M/d/yyyy"); }
		}

		public Payment ()
		{
		}
	}
}

