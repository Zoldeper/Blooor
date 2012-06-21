using Ahwa.Attila.Core.Android.Interface;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.ViewModels;
using Ahwa.Attila.Core.Android.Models;
using Cirrious.MvvmCross.Commands;
using Ahwa.Attila.Core.Android.ViewModels.MarketViewModels;
using Ahwa.Attila.Core.Android.ViewModels.CategoryViewModels;
using Ahwa.Attila.Core.Android.ViewModels.ProductViewModels;
using Ahwa.Attila.Core.Android.ViewModels.ShoppingItemViewModels;

namespace Ahwa.Attila.Core.Android.ViewModels.BaseViewModels
{
    public class BaseViewModel: MvxViewModel
        , IMvxServiceConsumer<IDataStore> 
    {
        protected IDataStore DataStore
        {
            get { return this.GetService<IDataStore>(); }
        }

        public MvxRelayCommand NavigateToMarketListViewModel
        {
            get
            {
                return new MvxRelayCommand(() =>
                {
                    RequestNavigate<MarketListViewModel>();
                });
            }
        }

        public MvxRelayCommand NavigateToCategoryListViewModel
        {
            get
            {
                return new MvxRelayCommand(() =>
                {
                    RequestNavigate<CategoryListViewModel>();
                });
            }
        }

        public MvxRelayCommand NavigateToProductListViewModel
        {
            get
            {
                return new MvxRelayCommand(() =>
                {
                    RequestNavigate<ProductListViewModel>();
                });
            }
        }

        public MvxRelayCommand NavigateToShoppingItemListViewModel
        {
            get
            {
                return new MvxRelayCommand(() =>
                {
                    RequestNavigate<ShoppingItemListViewModel>();
                });
            }
        }
    }
}