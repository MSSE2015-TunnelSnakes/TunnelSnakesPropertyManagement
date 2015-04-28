using System;
using SQLite.Net;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace TunnelSnakesPropertyManagement
{
	public class DatabaseHelper
	{
		static object locker = new object ();
		SQLiteConnection database;

		/// <summary>
		/// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
		/// if the database doesn't exist, it will create the database and all the tables.
		/// </summary>
		/// <param name='path'>
		/// Path.
		/// </param>
		public DatabaseHelper ()
		{
			database = DependencyService.Get<ISQLite> ().GetConnection ();
			// create the tables
			database.CreateTable<Tenant>();
			database.CreateTable<Property>();
			database.CreateTable<WorkRequest>();
			database.CreateTable<Address>();
			database.CreateTable<Payment>();
			database.CreateTable<Message>();
		}

		///
		/// Address
		/// 
		public Address GetAddress (int id) 
		{
			lock (locker) {
				return database.Table<Address>().FirstOrDefault(x => x.address_id == id);
			}
		}

		public int SaveAddress (Address address) 
		{
			lock (locker) {
				if (address.address_id != 0) {
					database.Update(address);
					return address.address_id;
				} else {
					return database.Insert(address);
				}
			}
		}

		public int DeleteAddress(int id)
		{
			lock (locker) {
				return database.Delete<Address>(id);
			}
		}

		///
		/// Property 
		///

		/// <summary>
		/// Gets the properties.
		/// </summary>
		/// <returns>The properties.</returns>
		public IEnumerable<Property> GetProperties ()
		{
			lock (locker) {
				return (from i in database.Table<Property>() select i).ToList();
			}
		}

		public IEnumerable<Property> GetOwnedNotOccupiedProperties ()
		{
			lock (locker) {
				return database.Query<Property>("SELECT * FROM [Property] WHERE [Owned] = 1 AND [Occupied] = 0");
			}
		}

		public Property GetProperty (int id) 
		{
			lock (locker) {
				return database.Table<Property>().FirstOrDefault(x => x.address_id == id);
			}
		}

		public int SaveProperty (Property property) 
		{
			lock (locker) {
				if (property.property_id != 0) {
					database.Update(property);
					return property.address_id;
				} else {
					return database.Insert(property);
				}
			}
		}

		public int DeleteProperty(int id)
		{
			lock (locker) {
				return database.Delete<Property>(id);
			}
		}
			
		///
		/// Tenant
		/// 
		public Tenant GetTenant (int id) 
		{
			lock (locker) {
				return database.Table<Tenant>().FirstOrDefault(x => x.tenant_id == id);
			}
		}


		// This is terrrrrrible - FIX
		public ObservableCollection<Tenant> GetAllTenants ()
		{
			lock (locker) {
				ObservableCollection<Tenant> tenants = new ObservableCollection<Tenant> ();
				IEnumerable<Tenant> tenantList = (from i in database.Table<Tenant>() select i).ToList();
				foreach (Tenant t in tenantList) {
					tenants.Add(t);
				}
				return tenants;
			}
		}

		public int SaveTenant (Tenant tenant) 
		{
			lock (locker) {
				if (tenant.tenant_id != 0) {
					database.Update(tenant);
					return tenant.tenant_id;
				} else {
					return database.Insert(tenant);
				}
			}
		}

		public int DeleteTenant(int id)
		{
			lock (locker) {
				return database.Delete<Tenant>(id);
			}
		}

	}
}

