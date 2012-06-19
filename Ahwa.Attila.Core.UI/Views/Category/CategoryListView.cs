using Android.App;
using Android.Views;
using Ahwa.Attila.Core.Android.ViewModels.CategoryViewModels;



namespace Ahwa.Attila.UI.Android.Views.Category
{
    [Activity(Label = "Category List", Icon = "@drawable/icon")]
    public class CategoryListView : BaseView<CategoryListViewModel>
    {
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.category_list_menu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.add_category:
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
            SetContentView(Resource.Layout.CategoryListView);
        }
    }
}
