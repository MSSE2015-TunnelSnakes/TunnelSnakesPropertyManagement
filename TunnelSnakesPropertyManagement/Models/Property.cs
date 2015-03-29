using System;
using SQLite.Net.Attributes;

namespace TunnelSnakesPropertyManagement
{
	public class Property
	{
		[PrimaryKey, AutoIncrement]
		public int proerty_id { get; set; }
		public string address_line_1 { get; set; }
		public string address_line_2 { get; set; }
		public string city { get; set; }
		public string state { get; set; }
		public string zip { get; set; }
		public int num_bedrooms { get; set; }
		public bool num_bathrooms { get; set; }
		public bool can_mix_tenants { get; set; }

		public Property ()
		{
		}
	}
}

