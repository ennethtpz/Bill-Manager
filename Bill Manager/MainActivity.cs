using Android.Content;
using Android.Runtime;
using CheeseBind;

namespace Bill_Manager;

[Activity(Label = "@string/home_title", MainLauncher = true)]
public class MainActivity : Activity
{
    public static int ADD_BILLER = 0;

    [BindView(Resource.Id.btnAddBiller)]
    Button btnAddBiller;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.activity_main);
    }

    [OnClick(Resource.Id.btnAddBiller)]
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
