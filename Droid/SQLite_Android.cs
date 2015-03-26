using System;
using Todo;
using Xamarin.Forms;
using Todo.iOS;
using System.IO;

[assembly: Dependency (typeof (SQLite_Android))]

namespace TunnelSnakesPropertyManagement.Droid
{
	public class SQLite_Android : ISQLite
	{
		public SQLite_Android ()
		{
		}

		#region ISQLite implementation
		public SQLite.Net.SQLiteConnection GetConnection ()
		{
			var path = Forms.Context.Resources.OpenRawResource(Resource.Raw.TSPM);
			var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
			var conn = new SQLite.Net.SQLiteConnection(plat, path);

			// Return the database connection 
			return conn;
		}
		#endregion
	}
}