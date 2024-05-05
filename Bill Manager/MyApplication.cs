using Android.Runtime;
using Bill_Manager.Entities;

namespace Bill_Manager
{
#if DEBUG
    [Application(Debuggable = true, LargeHeap = true)]
#else
    [Application(Debuggable = false, LargeHeap = true)]
#endif
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

