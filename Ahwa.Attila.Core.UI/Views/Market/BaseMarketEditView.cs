
using Android.Views;
using Ahwa.Attila.Core.Android.ViewModels.BaseViewModels;
namespace Ahwa.Attila.UI.Android.Views.Market
{
    public class BaseMarketEditView<TViewModel> :
        BaseView<TViewModel>
        where TViewModel : BaseEditObjectViewModel<Attila.Core.Android.Models.Market>
    {
        private readonly int _whichMenu;

        public BaseMarketEditView(int whichMenu)
        {
            _whichMenu = whichMenu;
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.MarketEditView);            
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
                case Resource.Id.save_market:
                    ViewModel.SaveCommand.Execute();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}