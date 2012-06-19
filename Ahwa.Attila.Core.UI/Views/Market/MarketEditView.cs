
using Ahwa.Attila.Core.Android.ViewModels.MarketViewModels;
using Android.App;
using Android.Views;

namespace Ahwa.Attila.UI.Android.Views.Market
{
    [Activity(Label = "Market editor", WindowSoftInputMode = SoftInput.AdjustPan)]
    public class MarketEditView : BaseMarketEditView<EditMarketViewModel>
    {
        public MarketEditView()
            : base(Resource.Menu.market_edit_menu)
        {
        }        
    }
}