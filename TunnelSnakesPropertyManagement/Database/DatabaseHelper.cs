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
			//database.StoreDateTimeAsTicks = true;
			// create the tables
			try {
				database.CreateTable<Tenant>();
				database.CreateTable<Property>();
				database.CreateTable<WorkRequest>();
				database.CreateTable<Address>();
				database.CreateTable<Payment>();
				database.CreateTable<Message>();
			} catch (Exception ex) {
				// Add error catching.  This could prompt the user that database is
				//  corrupt and needs to be rebuilt or something.
			}
		}

		// Scary!
		public void DropTables() {
			try {
				database.DropTable<Tenant>();
				database.DropTable<Property>();
				database.DropTable<WorkRequest>();
				database.DropTable<Address>();
				database.DropTable<Payment>();
				database.DropTable<Message>();
			} catch (Exception ex) {
				
			}
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


		public IEnumerable<Payment> GetPayments (DateTime? after, DateTime? before) //, bool isPaid)
		{
			lock (locker) {
				return (from x in database.Table<Payment>() where
					(after == null || x.due_date >= after)
					&& (before == null || x.due_date <= before)
//					&& ((isPaid && x.amount_paid >= x.amount_due)
//						|| (!isPaid && x.amount_paid < x.amount_due))
					select x).ToList();
			}
		}

		public int SavePayment (Payment payment) 
		{
			lock (locker) {
				if (payment.tenant_id != 0) {
					database.Update(payment);
					return payment.payment_id;
				} else {
					return database.Insert(payment);
				}
			}
		}

		public int DeletePayment(int id)
		{
			lock (locker) {
				return database.Delete<Payment>(id);
			}
		}
	}
}

