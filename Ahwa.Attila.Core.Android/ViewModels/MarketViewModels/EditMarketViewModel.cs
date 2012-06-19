using System;
using Cirrious.MvvmCross.Commands;
using Cirrious.MvvmCross.Interfaces.Commands;
using Ahwa.Attila.Core.Android.Models;

namespace Ahwa.Attila.Core.Android.ViewModels.MarketViewModels
{
    public class EditMarketViewModel : BaseEditMarketViewModel<Market>
    {
        public EditMarketViewModel(string id)
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
                                                       TraceHelper.Trace("There is a problem updating market data. Error description: {0}", exception.ToString());
                                                   }
                                               });
            }
        }
    }
}