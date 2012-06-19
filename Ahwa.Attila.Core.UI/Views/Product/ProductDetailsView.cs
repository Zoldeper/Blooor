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
    [Activity(Label = "Product Info", WindowSoftInputMode = SoftInput.AdjustPan)]
    public class ProductDetailsView : BaseView<DetailsProductViewModel>
    {
        private const int view_menu = Resource.Menu.product_menu;


        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.ProductDetailsView);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(view_menu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.change_product:
                    ViewModel.EditCommand.Execute();
                    return true;
                case Resource.Id.delete_product:
                    ViewModel.DeleteCommand.Execute();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}