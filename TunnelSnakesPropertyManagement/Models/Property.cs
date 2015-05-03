using System;
using SQLite.Net.Attributes;

namespace TunnelSnakesPropertyManagement
{
	public class Property
	{
		[PrimaryKey, AutoIncrement]
		public int property_id { get; set; }
		public int address_id { get; set; }
		public int num_bedrooms { get; set; }
		public int num_bathrooms { get; set; }
		public int can_mix_tenants { get; set; }

		public Property ()
		{
		}
	}

	public class PropertyAddress : Property
	{
		public PropertyAddress() {
			address = new Address ();
		}


		public Address address { get; set; }
	}
}

