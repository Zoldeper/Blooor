using System;
using Cirrious.MvvmCross.Commands;
using Cirrious.MvvmCross.Interfaces.Commands;
using Ahwa.Attila.Core.Android.ViewModels.MarketViewModels;
using Android.Locations;
using Ahwa.Attila.Core.Android.Models;

namespace Ahwa.Attila.Core.Android.ViewModels.MarketViewModels
{
    public class NewMarketViewModel : BaseEditMarketViewModel<Market>
    {
        public NewMarketViewModel()
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
                                                       TraceHelper.Trace("There is a problem creating market data. Error description: {0}", exception.ToString());
                                                   }
                                               });
            }
        }
    }
}