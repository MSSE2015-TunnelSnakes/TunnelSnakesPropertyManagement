using System;
using TunnelSnakesPropertyManagement;
using Xamarin.Forms;
using TunnelSnakesPropertyManagement.iOS;
using System.IO;

[assembly: Dependency (typeof (SQLite_iOS))]

namespace TunnelSnakesPropertyManagement.iOS
{
	public class SQLite_iOS : ISQLite
	{
		public SQLite_iOS ()
		{
		}

		#region ISQLite implementation
		public SQLite.Net.SQLiteConnection GetConnection ()
		{
			var sqliteFilename = "PropertyManagement.db3";
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
			string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
			var path = Path.Combine(libraryPath, sqliteFilename);

			// This is where we copy in the prepopulated database
			Console.WriteLine (path);
			if (!File.Exists (path)) {
				File.Copy (sqliteFilename, path);
			}

			var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
			var conn = new SQLite.Net.SQLiteConnection(plat, path);

			// Return the database connection 
			return conn;
		}
		#endregion
	}
}

