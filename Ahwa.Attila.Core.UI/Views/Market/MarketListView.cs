
using Ahwa.Attila.Core.Android.ViewModels.MarketViewModels;
using Android.App;
using Android.Views;
using Cirrious.MvvmCross.Application;



namespace Ahwa.Attila.UI.Android.Views.Market
{
    [Activity(Label = "Market List", Icon = "@drawable/icon")]
    public class MarketListView : BaseView<MarketListViewModel>
    {
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.market_list_menu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.add_market:
                    AddMarket();                    
                    return true;
                case Resource.Id.list_category:
                    ViewModel.NavigateToCategoryListViewModel.Execute();
                    return true;
                case Resource.Id.list_product:
                    ViewModel.NavigateToProductListViewModel.Execute();
                    return true;
                case Resource.Id.list_market:
                    ViewModel.NavigateToMarketListViewModel.Execute();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.MarketListView);
        }

        void AddMarket()
        {
            ViewModel.AddCommand.Execute();
        }
    }
}
