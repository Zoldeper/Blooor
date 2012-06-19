
using Ahwa.Attila.Core.Android.ViewModels.ProductViewModels;
using Android.App;
using Android.Views;

namespace Ahwa.Attila.UI.Android.Views.Product
{
    [Activity(Label = "New product", WindowSoftInputMode = SoftInput.AdjustPan)]
    public class ProductNewView : BaseProductEditView<NewProductViewModel>
    {
        private const int add_menu = Resource.Menu.product_add_menu;

        public ProductNewView()
            : base(add_menu)
        {
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
        }
    }
}