using Ahwa.Attila.Core.Android.ViewModels.MarketViewModels;
using Cirrious.MvvmCross.Interfaces.ViewModels;
using Cirrious.MvvmCross.ViewModels;
using Ahwa.Attila.Core.Android.ViewModels.ProductViewModels;
using Ahwa.Attila.Core.Android.ViewModels.ShoppingItemViewModels;

namespace Ahwa.Attila.Core.Android
{
    public class StartApplicationObject
        : MvxApplicationObject
        , IMvxStartNavigation
    {
        public void Start()
        {
            this.RequestNavigate<NewShoppingItemViewModel>();
        }

        public bool ApplicationCanOpenBookmarks
        {
            get { return false; }
        }
    }
}