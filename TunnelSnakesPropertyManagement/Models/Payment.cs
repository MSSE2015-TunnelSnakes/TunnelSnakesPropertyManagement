using System;
using SQLite.Net.Attributes;

namespace TunnelSnakesPropertyManagement
{
	public class Payment
	{
		public int property_id { get; set; }
		public int tenant_id { get; set; }
		public string due_date { get; set; }
		public string amount_due { get; set; }
		public string amount_paid { get; set; }

		public Payment ()
		{
		}
	}
}

