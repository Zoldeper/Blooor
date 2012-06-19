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
using Cirrious.MvvmCross.Interfaces.Commands;
using Cirrious.MvvmCross.Commands;
using Ahwa.Attila.Core.Android.Models;
using Ahwa.Attila.Core.Android.ViewModels.BaseViewModels;

namespace Ahwa.Attila.Core.Android.ViewModels.CategoryViewModels
{
    public class NewCategoryViewModel: BaseEditObjectViewModel<Category>
    {
        public NewCategoryViewModel()
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
                        TraceHelper.Trace("There is a problem creating category data. Error description: {0}", exception.ToString());
                    }
                });
            }
        }
    }
}