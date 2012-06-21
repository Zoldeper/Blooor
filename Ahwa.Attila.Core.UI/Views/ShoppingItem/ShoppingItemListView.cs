using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Ahwa.Attila.Core.Android.ViewModels.ShoppingItemViewModels;

namespace Ahwa.Attila.UI.Android.Views.ShoppingItem
{
    [Activity(Label = ShoppingItemHelper.LIST_OBJECT_VIEW_TITLE, Icon = "@drawable/icon")]
    public class ShoppingItemListView : BaseView<ShoppingItemListViewModel>
    {
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(ShoppingItemHelper.VIEW_OBJECT_MENU, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.add_shoppingitem:
                    ViewModel.AddCommand.Execute();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        protected override void OnViewModelSet()
        {
            SetContentView(ShoppingItemHelper.LIST_CONTENT);
        }
    }
}
