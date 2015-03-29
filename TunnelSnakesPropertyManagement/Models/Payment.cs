using System;

namespace TunnelSnakesPropertyManagement
{
	public class Payment
	{
		public Payment ()
		{
			[PrimaryKey, AutoIncrement]
			public int payment_id { get; set; }
			public string due_date { get; set; }
			public string amount_due { get; set; }
			public string amount_paid { get; set; }
		}
	}
}

