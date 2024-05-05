using System.Collections.Generic;
using Android.Content;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Bill_Manager.Entities;
using static Android.App.Assist.AssistStructure;

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
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_billeraccount_row, parent, false);
            return new BillerAccountViewHolder(view);
        }

        #endregion
    }

    class BillerAccountViewHolder : RecyclerView.ViewHolder
    {
        #region Properties

        public TextView txtTitle { get; private set; }

        #endregion

        #region Constructor

        public BillerAccountViewHolder(View itemView) : base(itemView)
        {
            txtTitle = itemView.FindViewById<TextView>(Resource.Id.txtTitle);
        }

        #endregion
    }
}

