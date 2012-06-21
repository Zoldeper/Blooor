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
using Ahwa.Attila.Core.Android.Models;
using Cirrious.MvvmCross.Interfaces.Commands;
using Cirrious.MvvmCross.Commands;

namespace Ahwa.Attila.Core.Android.ViewModels.ShoppingItemViewModels
{
    public class NewShoppingItemViewModel: BaseEditShoppingItemViewModel<ShoppingItem>
    {
        public NewShoppingItemViewModel()
            : base(null)
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
                        AddNew();
                        RequestClose(this);
                    }
                    catch (Exception exception)
                    {
                        TraceHelper.Trace("There is a problem creating shopping item data. Error description: {0}", exception.ToString());
                    }
                });
            }
        }
    }
}