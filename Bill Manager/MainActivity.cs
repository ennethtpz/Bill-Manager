using Android.Content;
using Android.Runtime;
using AndroidX.RecyclerView.Widget;
using Bill_Manager.Adapters;
using Bill_Manager.Entities;
using Newtonsoft.Json;

namespace Bill_Manager;

[Activity(Label = "@string/home_title", MainLauncher = true)]
public class MainActivity : Activity
{
    public static int ADD_BILLER = 0;
    public static string KEY_NEWACCOUNT = "newAcct";

    Button btnAddBiller;
    RecyclerView rcvBillers;

    List<BillerAccount> accountsList;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);

        btnAddBiller = (Button)FindViewById(Resource.Id.btnAddBiller);
        rcvBillers = (RecyclerView)FindViewById(Resource.Id.rcvBillers);

        btnAddBiller.Click += BtnAddBiller_Click;

        var accountsList = BillerAccount.GetAll();
        if (accountsList != null && accountsList.Count > 0)
        {
            var layoutMngr = new LinearLayoutManager(this, LinearLayoutManager.Vertical, false);
            var adapter = new BillerAccountsAdapter(this, accountsList);
            rcvBillers.SetLayoutManager(layoutMngr);
            rcvBillers.SetAdapter(adapter);
        }
    }

    private void BtnAddBiller_Click(object? sender, EventArgs e)
    {
        var i = new Intent(this, typeof(AddBillerActivity));
        StartActivityForResult(i, ADD_BILLER);
    }

    protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent? data)
    {
        base.OnActivityResult(requestCode, resultCode, data);

        if (requestCode == ADD_BILLER
            && resultCode == Result.Ok
            && data != null
            && data.Extras != null
            && rcvBillers.GetAdapter() is BillerAccountsAdapter adapter)
        {

            string? newAccntJson = data.Extras.GetString(KEY_NEWACCOUNT);
            if (!string.IsNullOrEmpty(newAccntJson))
            {
                var newAcct = JsonConvert.DeserializeObject<BillerAccount>(newAccntJson);
                if (newAcct != null)
                    adapter.AddItem(newAcct);
            }

            Toast.MakeText(this, Resource.String.toast_account_added, ToastLength.Short).Show();
        }
    }
}
