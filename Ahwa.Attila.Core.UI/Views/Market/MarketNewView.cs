
using Ahwa.Attila.Core.Android.ViewModels.MarketViewModels;
using Android.App;
using Android.Views;

namespace Ahwa.Attila.UI.Android.Views.Market
{
    [Activity(Label = "New market", WindowSoftInputMode = SoftInput.AdjustPan)]
    public class MarketNewView : BaseMarketEditView<NewMarketViewModel>
    {
        public MarketNewView()
            : base(Resource.Menu.market_add_menu)
        {
        }

        protected override void OnViewModelSet()
        {            
            base.OnViewModelSet();
        }
    }
}