using Android.Content;
using Android.Runtime;

namespace Bill_Manager;

[Activity(Label = "@string/home_title", MainLauncher = true)]
public class MainActivity : Activity
{
    public static int ADD_BILLER = 0;

    Button btnAddBiller;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);

        btnAddBiller = (Button)FindViewById(Resource.Id.btnAddBiller);
        btnAddBiller.Click += BtnAddBiller_Click;
    }

    private void BtnAddBiller_Click(object? sender, EventArgs e)
    {
        var i = new Intent(this, typeof(AddBillerActivity));
        StartActivityForResult(i, ADD_BILLER);
    }

    protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent? data)
    {
        base.OnActivityResult(requestCode, resultCode, data);

        if (requestCode == ADD_BILLER && resultCode == Result.Ok)
        {
            //TODO: Refresh recyclerview here!
        }
    }
}
