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
using Ahwa.Attila.Core.Android.ViewModels.BaseViewModels;
using Cirrious.MvvmCross.Interfaces.Commands;
using Cirrious.MvvmCross.Commands;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.Interfaces.Platform.Tasks;

namespace Ahwa.Attila.Core.Android.ViewModels.ProductViewModels
{
    public class EditProductViewModel : BaseEditProductViewModel<Product>
    {
        public EditProductViewModel(string id)
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
                                                       TraceHelper.Trace("There is a problem updating product data. Error description: {0}", exception.ToString());
                                                   }
                                               });
            }
        }        
    }
}