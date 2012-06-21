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
using Ahwa.Attila.Core.Android.ViewModels.BaseViewModels;

namespace Ahwa.Attila.UI.Android.Views.ShoppingItem
{
    public class BaseShoppingItemEditView<TViewModel> :
        BaseView<TViewModel>
        where TViewModel : BaseEditObjectViewModel<Ahwa.Attila.Core.Android.Models.ShoppingItem>
    {
        

        private readonly int _whichMenu;

        public BaseShoppingItemEditView(int whichMenu)
        {
            _whichMenu = whichMenu;
        }

        protected override void OnViewModelSet()
        {
            SetContentView(ShoppingItemHelper.EDIT_CONTENT);            
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(_whichMenu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case ShoppingItemHelper.SAVE_OBJECT_MENU:
                    ViewModel.SaveCommand.Execute();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}