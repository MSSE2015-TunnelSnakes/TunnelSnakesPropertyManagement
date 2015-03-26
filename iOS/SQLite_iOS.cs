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
			var sqliteFilename = "TSPM.db3";
			var resourcesPath = Environment.GetFolderPath(Environment.SpecialFolder.Resources);
			var path = Path.Combine(resourcesPath, sqliteFilename);
			var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
			var conn = new SQLite.Net.SQLiteConnection(plat, path);

			// Return the database connection 
			return conn;
		}
		#endregion
	}
}

