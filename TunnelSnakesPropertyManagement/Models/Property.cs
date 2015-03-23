using System;
using SQLite.Net.Attributes;

namespace TunnelSnakesPropertyManagement
{
	public class Property
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public int Capacity { get; set; }
		public bool Owned { get; set; }
		public bool Occupied { get; set; }

		public Property ()
		{
		}
	}
}

