using System;
using SQLite.Net.Attributes;

namespace TunnelSnakesPropertyManagement
{
	public class WorkRequest
	{
		[PrimaryKey, AutoIncrement]
		public int work_request_id { get; set; }
		public int property_id { get; set; }
		public int planned { get; set; }
		public string cost { get; set; }

		public WorkRequest ()
		{
		}
	}
}

