using System;

using Cirrious.MvvmCross.Interfaces.Commands;
using Cirrious.MvvmCross.Commands;
using Ahwa.Attila.Core.Android.Models;
using Ahwa.Attila.Core.Android.ViewModels.BaseViewModels;

namespace Ahwa.Attila.Core.Android.ViewModels.CategoryViewModels
{
        public class EditCategoryViewModel : BaseEditObjectViewModel<Category>
        {
            public EditCategoryViewModel(string id)
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
                                                           TraceHelper.Trace("There is a problem updating category data. Error description: {0}", exception.ToString());
                                                       }
                                                   });
                }
            }
        }
    }