

using Android.App;
using Ahwa.Attila.Core.Android.ViewModels.MarketViewModels;
using Android.Views;
namespace Ahwa.Attila.UI.Android.Views.Market
{
    [Activity(Label = "Market Info", WindowSoftInputMode = SoftInput.AdjustPan)]
    public class MarketDetailsView : BaseView<DetailsMarketViewModel>    
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.MarketDetailsView);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.market_menu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.change_market:
                    ViewModel.EditCommand.Execute();
                    return true;
                case Resource.Id.delete_market:
                    ViewModel.DeleteCommand.Execute();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}