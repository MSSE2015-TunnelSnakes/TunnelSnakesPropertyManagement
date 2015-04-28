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

		public Payment ()
		{
		}
	}
}

