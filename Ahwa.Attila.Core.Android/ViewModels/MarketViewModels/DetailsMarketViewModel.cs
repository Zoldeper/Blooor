using System;
using Ahwa.Attila.Core.Android.Models;
using Cirrious.MvvmCross.Commands;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.Commands;
using Cirrious.MvvmCross.Interfaces.Platform.Tasks;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.ShortNames;
using Ahwa.Attila.Core.Android.ViewModels.BaseViewModels;

namespace Ahwa.Attila.Core.Android.ViewModels.MarketViewModels
{
    public class DetailsMarketViewModel: DetailsObjectViewModel<Market>
        , IMvxServiceConsumer<IMvxWebBrowserTask>        
    {
        public DetailsMarketViewModel(string id) : base (id)
        {
        }

        public override MvxRelayCommand NavigateToEditViewModel()
        {
            return new MvxRelayCommand(() =>
            {
                RequestNavigate<EditMarketViewModel>(new StringDict() { { "id", Model.ID } });
            });
        }

        public IMvxCommand ShowOnMapCommand
        {
            get
            {
                return new MvxRelayCommand(() =>
                {
                    string googleAddress = string.Format("{0},{1}",
                                                         Model.Latitude.ToString().Replace(',', '.'),
                                                         Model.Longitude.ToString().Replace(',', '.'));
                    googleAddress = Uri.EscapeUriString(googleAddress);

                    string url = string.Format("http://maps.google.com/maps?ll={0}",
                                               googleAddress);
                    this.GetService<IMvxWebBrowserTask>().ShowWebPage(url);
                });
            }
        }
    }
}
