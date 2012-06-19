using System;
using Ahwa.Attila.Core.Android.Models;
using Cirrious.MvvmCross.Commands;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.Commands;
using Cirrious.MvvmCross.Interfaces.Platform.Location;
using Cirrious.MvvmCross.Interfaces.Platform.Tasks;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Ahwa.Attila.Core.Android.ViewModels.BaseViewModels;

namespace Ahwa.Attila.Core.Android.ViewModels.MarketViewModels
{
    public abstract class BaseEditMarketViewModel<T>
        : BaseEditObjectViewModel<Market>, IMvxServiceConsumer<IMvxGeoLocationWatcher>, IMvxServiceConsumer<IMvxWebBrowserTask>  where T : Market, new()
    {
        private readonly IMvxGeoLocationWatcher _watcher;

        protected BaseEditMarketViewModel(string id):base(id)
        {            
            _watcher = this.GetService<IMvxGeoLocationWatcher>();
            ViewUnRegistered += OnViewUnRegistered;
            DoStartStop();
        }

        public IMvxCommand ShowOnMapCommand
        {
            get
            {
                return new MvxRelayCommand(() =>
                {
                    string googleAddress = string.Format("{0},{1}",
                                                         Model.Latitude.ToString().Replace(',','.'),
                                                         Model.Longitude.ToString().Replace(',', '.'));
                    googleAddress = Uri.EscapeUriString(googleAddress);

                    string url = string.Format("http://maps.google.com/maps?ll={0}",
                                               googleAddress);
                    this.GetService<IMvxWebBrowserTask>().ShowWebPage(url);
                });
            }
        }

        public IMvxCommand UpdateCoordinatesCommand
        {
            get
            {
                return new MvxRelayCommand(() =>
                {
                    try
                    {
                        UpdateMarketCoordinates();
                    }
                    catch (Exception exception)
                    {
                        TraceHelper.Trace("There is a problem getting market coordinates. Error description: {0}", exception.ToString());
                    }
                });
            }
        }

        private void UpdateMarketCoordinates()
        {
            Model.Longitude = Longitude;
            Model.Latitude = Latitude;
        }

        #region location related code
        private void OnViewUnRegistered(object sender, EventArgs eventArgs)
        {
            if (IsStarted)
            {
                DoStartStop();
            }
        }

        private bool _isStarted;
        public bool IsStarted
        {
            get { return _isStarted; }
            set { _isStarted = value; FirePropertyChanged(() => IsStarted); }
        }

        private double _Latitude;
        public double Latitude
        {
            get { return _Latitude; }
            set { _Latitude = value; FirePropertyChanged(() => Latitude); }
        }

        private double _Longitude;
        public double Longitude
        {
            get { return _Longitude; }
            set { _Longitude = value; FirePropertyChanged(() => Longitude); }
        }

        private string _lastError;
        public string LastError
        {
            get { return _lastError; }
            set { _lastError = value; FirePropertyChanged(() => LastError); }
        }

        public IMvxCommand StartStopCommand
        {
            get
            {
                return new MvxRelayCommand(DoStartStop);
            }
        }

        private void DoStartStop()
        {
            if (!IsStarted)
            {
                _watcher.Start(new MvxGeoLocationOptions() {  EnableHighAccuracy  = false}, OnNewLocation, OnError);
            }
            else
            {
                _watcher.Stop();
            }

            IsStarted = !IsStarted;
        }

        private void OnError(MvxLocationError error)
        {
            TraceHelper.Trace("Error getting location", error.ToString());
        }

        private void OnNewLocation(MvxGeoLocation location)
        {
            if (location != null && location.Coordinates != null)
            {
                Latitude = location.Coordinates.Latitude;
                Longitude = location.Coordinates.Longitude;
            }
        }
        #endregion
    }
}