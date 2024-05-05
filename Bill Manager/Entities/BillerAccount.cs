using Android.Nfc;
using Bill_Manager.DataAccess;
using SQLite;

namespace Bill_Manager.Entities
{
	[Table("BillerAccounts")]
	public class BillerAccount
	{
		[Unique, Column("BillerID")]
		public string BillerID { get; set; }

        [Column("Title")]
        public string Title { get; set; }

        [Column("AccountName")]
        public string AccountName { get; set; }

        [Column("AccountNo")]
        public string AccountNo { get; set; }

        [Column("DateAdded")]
        public DateTime DateAdded { get; set; }


        public BillerAccount()
		{

		}

        public static int CreateTable()
        {
            using var db = DBHelper.GetSQLiteConnection();
            return (int)db.CreateTable<BillerAccount>();
        }

        public static int InsertOrReplace(ref BillerAccount account)
        {
            using var db = DBHelper.GetSQLiteConnection();

            if (string.IsNullOrEmpty(account.BillerID))
            {
                account.BillerID = Guid.NewGuid().ToString();
                account.DateAdded = DateTime.Now;
            }

            return db.InsertOrReplace(account);
        }

        public static int DeleteRecord(BillerAccount account)
        {
            using var db = DBHelper.GetSQLiteConnection();
            return db.Execute("DELETE FROM BillerAccounts WHERE BillerID = ?", account.BillerID);
        }

        public static List<BillerAccount> GetAll()
        {
            using var db = DBHelper.GetSQLiteConnection();
            return db.Query<BillerAccount>("SELECT * FROM BillerAccounts").ToList();
        }
	}
}

