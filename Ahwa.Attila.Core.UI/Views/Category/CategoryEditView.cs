
using Ahwa.Attila.Core.Android.ViewModels.CategoryViewModels;
using Android.App;
using Android.Views;

namespace Ahwa.Attila.UI.Android.Views.Category
{
    [Activity(Label = "Category editor", WindowSoftInputMode = SoftInput.AdjustPan)]
    public class CategoryEditView : BaseCategoryEditView<EditCategoryViewModel>
    {
        public CategoryEditView()
            : base(Resource.Menu.category_edit_menu)
        {
        }        
    }
}