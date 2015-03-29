using System;
using SQLite.Net.Attributes;

namespace TunnelSnakesPropertyManagement
{
	public class Address
	{
		[PrimaryKey, AutoIncrement]
		public int address_id { get; set; }
		public string address_line_1 { get; set; }
		public string address_line_2 { get; set; }
		public string city { get; set; }
		public string state { get; set; }
		public string zip { get; set; }

		public Address ()
		{
		}
	}
}

