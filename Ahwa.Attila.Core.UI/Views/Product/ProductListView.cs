
using Ahwa.Attila.Core.Android.ViewModels.ProductViewModels;
using Android.App;
using Android.Views;

namespace Ahwa.Attila.UI.Android.Views.Product
{
    [Activity(Label = "Product List", Icon = "@drawable/icon")]
    public class ProductListView : BaseView<ProductListViewModel>
    {
        private const int view_menu = Resource.Menu.product_list_menu;
        private const int content = Resource.Layout.ProductListView;

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(view_menu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.add_product:
                    ViewModel.AddCommand.Execute();
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
            SetContentView(content);
        }
    }
}
