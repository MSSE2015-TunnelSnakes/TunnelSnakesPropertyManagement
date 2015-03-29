using System;
using SQLite.Net.Attributes;

namespace TunnelSnakesPropertyManagement
{
	public class Message
	{
		[PrimaryKey, AutoIncrement]
		public int message_id { get; set; }
		public int tenant_id { get; set; }
		public string content { get; set; }

		public Message ()
		{
		}
	}
}

