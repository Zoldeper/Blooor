

using Android.App;
using Ahwa.Attila.Core.Android.ViewModels.CategoryViewModels;
using Android.Views;
namespace Ahwa.Attila.UI.Android.Views.Category
{
    [Activity(Label = "Category Info", WindowSoftInputMode = SoftInput.AdjustPan)]
    public class CategroyDetailsView : BaseView<DetailsCategoryViewModel>    
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.CategoryDetailsView);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.category_menu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.change_category:
                    ViewModel.EditCommand.Execute();
                    return true;
                case Resource.Id.delete_category:
                    ViewModel.DeleteCommand.Execute();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}