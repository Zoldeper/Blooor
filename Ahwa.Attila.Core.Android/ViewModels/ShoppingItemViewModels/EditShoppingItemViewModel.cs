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
using Ahwa.Attila.Core.Android.Models;
using Cirrious.MvvmCross.Interfaces.Commands;
using Cirrious.MvvmCross.Commands;

namespace Ahwa.Attila.Core.Android.ViewModels.ShoppingItemViewModels
{
    public class EditShoppingItemViewModel: BaseEditShoppingItemViewModel<ShoppingItem>
    {
        public EditShoppingItemViewModel(string id)
            : base(id)
        {
        }

        public override IMvxCommand SaveCommand
        {
            get
            {
                return new MvxRelayCommand(() =>
                                               {
                                                   try
                                                   {
                                                       Update();
                                                       RequestClose(this);
                                                   }
                                                   catch (Exception exception)
                                                   {
                                                       TraceHelper.Trace("There is a problem updating shopping item data. Error description: {0}", exception.ToString());
                                                   }
                                               });
            }
        }        
    }
}