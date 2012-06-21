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
using Ahwa.Attila.Core.Android.ViewModels.ShoppingItemViewModels;

namespace Ahwa.Attila.UI.Android.Views.ShoppingItem
{
    [Activity(Label = ShoppingItemHelper.NEW_OBJECT_VIEW_TITLE, WindowSoftInputMode = SoftInput.AdjustPan)]
    public class ShoppingItemNewView: BaseShoppingItemEditView<NewShoppingItemViewModel>
    {
        public ShoppingItemNewView()
            : base(ShoppingItemHelper.ADD_OBJECT_MENU)
        {
        }
    }
}