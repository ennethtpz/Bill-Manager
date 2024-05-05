using Android.Content;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Bill_Manager.Entities;

namespace Bill_Manager.Adapters
{
	public class BillerAccountsAdapter : RecyclerView.Adapter
    {
        #region Properties

        private List<BillerAccount> items;
        private Context context;

        #endregion

        #region Constructor

        public BillerAccountsAdapter(Context context, List<BillerAccount> items)
        {
            this.context = context;
            this.items = items;
        }

        public void UpdateData(List<BillerAccount> updatedItems)
        {
            items.Clear();
            items.AddRange(updatedItems);
            NotifyDataSetChanged();
        }

        public void AddItem(BillerAccount newBillerAccount)
        {
            items.Add(newBillerAccount);
            NotifyDataSetChanged();
        }

        #endregion

        #region Overidden Methods

        public override int ItemCount => items.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var account = items[position];

            if (holder is BillerAccountViewHolder viewHolder)
            {
                viewHolder.txtTitle.Text = account.Title;

                viewHolder.llItemContainer.Click += (s, e) => {
                    BillerAccount_Click(position);
                };
                viewHolder.llItemContainer.LongClick += (s, e) => {
                    BillerAccount_LongClick(position);
                };
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_billeraccount_row, parent, false);
            return new BillerAccountViewHolder(view);
        }

        #endregion

        private void BillerAccount_Click(int position)
        {
            string message = "Item clicked! " + position.ToString();
            Toast.MakeText(context, message, ToastLength.Short).Show();
        }

        private void BillerAccount_LongClick(int position)
        {
            var account = items[position];

            AlertDialog alertDialog = new AlertDialog.Builder(context).Create();
            alertDialog.SetTitle(context.GetString(Resource.String.delete_biller_title));
            alertDialog.SetMessage(string.Format(context.GetString(Resource.String.delete_message), account.Title));
            alertDialog.SetButton(context.GetString(Resource.String.yes), (s, e) => {
                alertDialog.Dismiss();
                // TODO: Count child records first, before deleting a biller!
                BillerAccount.DeleteRecord(account);
                items.RemoveAll(x => x.BillerID.Equals(account.BillerID, StringComparison.OrdinalIgnoreCase));
                NotifyDataSetChanged();
                Toast.MakeText(context, Resource.String.toast_account_deleted, ToastLength.Short).Show();
            });
            alertDialog.SetButton2(context.GetString(Resource.String.cancel), (s, e) => {
                alertDialog.Dismiss();
            });
            alertDialog.SetCancelable(true);
            alertDialog.Show();

        }
    }

    class BillerAccountViewHolder : RecyclerView.ViewHolder
    {
        #region Properties

        public LinearLayout llItemContainer { get; private set; }
        public TextView txtTitle { get; private set; }

        #endregion

        #region Constructor

        public BillerAccountViewHolder(View itemView) : base(itemView)
        {
            llItemContainer = itemView.FindViewById<LinearLayout>(Resource.Id.llItemContainer);
            txtTitle = itemView.FindViewById<TextView>(Resource.Id.txtTitle);
        }

        #endregion
    }
}

