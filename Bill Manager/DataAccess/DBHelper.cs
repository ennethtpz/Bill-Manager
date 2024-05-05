using SQLite;

namespace Bill_Manager.DataAccess
{
	public static class DBHelper
	{
		internal static readonly string DB_NAME = "RSTBillManager.db3";

		public static SQLiteConnection GetSQLiteConnection()
		{
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), DB_NAME);
            SQLiteConnection sQLiteConnection = new SQLiteConnection(databasePath);
            return sQLiteConnection;
        }
    }
}

