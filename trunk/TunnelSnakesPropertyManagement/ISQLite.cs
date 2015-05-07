using System;
using SQLite.Net;

namespace TunnelSnakesPropertyManagement
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}

