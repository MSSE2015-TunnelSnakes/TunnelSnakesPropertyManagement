using System;
using SQLite.Net;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

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
				return database.Table<Property>().FirstOrDefault(x => x.Id == id);
			}
		}

		public int SaveProperty (Property property) 
		{
			lock (locker) {
				if (property.Id != 0) {
					database.Update(property);
					return property.Id;
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


	}
}

