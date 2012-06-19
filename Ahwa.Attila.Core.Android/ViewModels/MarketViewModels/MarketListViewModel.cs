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
using Ahwa.Attila.Core.Android.Interface;
using Ahwa.Attila.Core.Android.Models;
using Cirrious.MvvmCross.Interfaces.Commands;
using Cirrious.MvvmCross.Commands;
using Ahwa.Attila.Core.Android.ViewModels.BaseViewModels;

namespace Ahwa.Attila.Core.Android.ViewModels.MarketViewModels
{
    public class MarketListViewModel: ObjectListViewModel<Market>
    {
        public MarketListViewModel():base()
        {
            
        }

        public override IMvxCommand NavigateToDetailsViewModel()
        {
            return new MvxRelayCommand<Market>((model) => RequestNavigate<DetailsMarketViewModel>(new { id = model.ID }));
        }

        public override IMvxCommand NavigateToNewViewModel()
        {
            return new MvxRelayCommand(() => RequestNavigate<NewMarketViewModel>());
        }
    }
}