using Cirrious.MvvmCross.Binding.Android.Views;
using Cirrious.MvvmCross.Interfaces.ViewModels;
using Ahwa.Attila.Core.Android.ViewModels.BaseViewModels;
using Android.Views;

namespace Ahwa.Attila.UI.Android.Views
{
    public abstract class BaseView<TViewModel>
        : MvxBindingActivityView<TViewModel>
        where TViewModel : BaseViewModel
    {
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {                
                case Resource.Id.list_category:
                    ViewModel.NavigateToCategoryListViewModel.Execute();
                    return true;
                case Resource.Id.list_product:
                    ViewModel.NavigateToProductListViewModel.Execute();
                    return true;
                case Resource.Id.list_market:
                    ViewModel.NavigateToMarketListViewModel.Execute();
                    return true;
                case Resource.Id.list_shoppingitem:
                    ViewModel.NavigateToShoppingItemListViewModel.Execute();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}