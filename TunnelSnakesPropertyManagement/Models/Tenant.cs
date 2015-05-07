using System;
using SQLite.Net.Attributes;

namespace TunnelSnakesPropertyManagement
{
	public class Tenant
	{
		[PrimaryKey, AutoIncrement]
		public int tenant_id { get; set; }
		public int address_id { get; set; }
		public int property_id { get; set; }
		public string first_name { get; set; }
		public string last_name { get; set; }
		public string phone_home { get; set; }
		public string phone_cell { get; set; }
		public string email { get; set; }
		public string lease_start_date { get; set; }
		public string lease_end_date { get; set; }

		[Ignore]
		public string Name
		{
			get 
			{
				return tenant_id + ". " + first_name + " " + last_name;
			}
		}

		public Tenant ()
		{
		}
	}
}

