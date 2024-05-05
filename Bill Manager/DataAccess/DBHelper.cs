using SQLite;

namespace Bill_Manager.DataAccess
{
	public class DBHelper
	{
		internal static string DB_LOCATION => System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
		internal static readonly string DB_NAME = "RSTBillManager.db3";
		internal static readonly string DB_PATH = Path.Combine(DB_LOCATION, DB_NAME);

		private static SQLiteConnection sQLiteConnection = null;

		public DBHelper()
		{

		}

		public static SQLiteConnection GetSQLiteConnection()
		{
			if (sQLiteConnection != null)
				return sQLiteConnection;
			else
			{
                sQLiteConnection = new SQLiteConnection(DB_PATH, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex, true);
				return sQLiteConnection;
            }				
		}
	}
}

