using Android.Content;

namespace Bill_Manager;

[Activity(Label = "@string/add_biller_title")]
public class AddBillerActivity : Activity
{
    Button btnAddBiller;
    EditText etxtTitle;
    EditText etxtAcctName;
    EditText etxtAcctNo;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        SetContentView(Resource.Layout.activity_addbiller);

        btnAddBiller = (Button)FindViewById(Resource.Id.btnAddBiller);
        etxtTitle = (EditText)FindViewById(Resource.Id.etxtTitle);
        etxtAcctName = (EditText)FindViewById(Resource.Id.etxtAcctName);
        etxtAcctNo = (EditText)FindViewById(Resource.Id.etxtAcctNo);

        btnAddBiller.Click += BtnAddBiller_Click;
    }

    private void BtnAddBiller_Click(object? sender, EventArgs e)
    {
        if (ValidateFields())
        {
            //TODO: Add saving logic

            var i = new Intent();
            SetResult(Result.Ok, i);
            Finish();
        }
        else
            Toast.MakeText(this, Resource.String.toast_incomplete_fields, ToastLength.Short).Show();
    }

    private bool ValidateFields()
    {
        bool isValid = true;

        if (string.IsNullOrWhiteSpace(etxtTitle.Text))
            isValid = false;
        if (string.IsNullOrWhiteSpace(etxtAcctName.Text))
            isValid = false;
        if (string.IsNullOrWhiteSpace(etxtAcctNo.Text))
            isValid = false;

        return isValid;
    }
}
