using Ahwa.Attila.Core.Android.ViewModels.MarketViewModels;
using Cirrious.MvvmCross.Interfaces.ViewModels;
using Cirrious.MvvmCross.ViewModels;
using Ahwa.Attila.Core.Android.ViewModels.ProductViewModels;

namespace Ahwa.Attila.Core.Android
{
    public class StartApplicationObject
        : MvxApplicationObject
        , IMvxStartNavigation
    {
        public void Start()
        {
            this.RequestNavigate<ProductListViewModel>();
        }

        public bool ApplicationCanOpenBookmarks
        {
            get { return false; }
        }
    }
}