
using Ahwa.Attila.Core.Android.ViewModels.CategoryViewModels;
using Android.App;
using Android.Views;

namespace Ahwa.Attila.UI.Android.Views.Category
{
    [Activity(Label = "New category", WindowSoftInputMode = SoftInput.AdjustPan)]
    public class CategoryNewView : BaseCategoryEditView<NewCategoryViewModel>
    {
        public CategoryNewView()
            : base(Resource.Menu.category_add_menu)
        {
        }
    }
}