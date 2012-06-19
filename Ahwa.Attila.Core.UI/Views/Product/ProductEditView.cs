using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Ahwa.Attila.Core.Android.ViewModels.ProductViewModels;

namespace Ahwa.Attila.UI.Android.Views.Product
{
    [Activity(Label = "Product editor", WindowSoftInputMode = SoftInput.AdjustPan)]
    public class ProductEditView: BaseProductEditView<EditProductViewModel>
    {
        public ProductEditView()
            : base(Resource.Menu.product_edit_menu)
        {
        }        
    }
}