using System;
using Ahwa.Attila.Core.Android.Models;
using Cirrious.MvvmCross.Commands;
using Cirrious.MvvmCross.Interfaces.Commands;

namespace Ahwa.Attila.Core.Android.ViewModels.ProductViewModels
{
    public class NewProductViewModel : BaseEditProductViewModel<Product>
    {
        public NewProductViewModel()
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
                        TraceHelper.Trace("There is a problem creating product data. Error description: {0}", exception.ToString());
                    }
                });
            }
        }
    }
}