using System;
using SQLite.Net.Attributes;

namespace TunnelSnakesPropertyManagement
{
	public class Tenant
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public string Notes { get; set; }
		public int CurrentProperty { get; set; }
		public bool CurrentRenter { get; set; }

		public Tenant ()
		{
		}
	}
}

