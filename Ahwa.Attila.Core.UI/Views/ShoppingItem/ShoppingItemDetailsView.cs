
using Ahwa.Attila.Core.Android.ViewModels.ShoppingItemViewModels;
using Android.App;
using Android.Views;

namespace Ahwa.Attila.UI.Android.Views.ShoppingItem
{
    [Activity(Label = ShoppingItemHelper.DETAIL_OBJECT_VIEW_TITLE, WindowSoftInputMode = SoftInput.AdjustPan)]
    public class ShoppingItemDetailsView : BaseView<DetailsShoppingItemViewModel>
    {
        protected override void OnViewModelSet()
        {
            SetContentView(ShoppingItemHelper.DETAIL_CONTENT);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(ShoppingItemHelper.LIST_OBJECT_MENU, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case ShoppingItemHelper.CHANGE_OBJECT_MENU:
                    ViewModel.EditCommand.Execute();
                    return true;
                case ShoppingItemHelper.DELETE_OBJECT_MENU:
                    ViewModel.DeleteCommand.Execute();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}