using Android.Runtime;
using Bill_Manager.Entities;

namespace Bill_Manager
{
    public class MyBillManagerApplication : Application
    {
        public MyBillManagerApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {

        }

        public override void OnCreate()
        {
            base.OnCreate();

            BillerAccount.CreateTable();
        }
    }
}

