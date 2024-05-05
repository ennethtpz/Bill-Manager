using Android.Content;
using CheeseBind;

namespace Bill_Manager;

[Activity(Label = "@string/add_biller_title")]
public class AddBillerActivity : Activity
{
    [BindView(Resource.Id.btnAddBiller)]
    Button btnAddBiller;

    [BindView(Resource.Id.etxtTitle)]
    EditText etxtTitle;

    [BindView(Resource.Id.etxtAcctName)]
    EditText etxtAcctName;

    [BindView(Resource.Id.etxtAcctNo)]
    EditText etxtAcctNo;

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.activity_addbiller);
    }

    [OnClick(Resource.Id.btnAddBiller)]
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
