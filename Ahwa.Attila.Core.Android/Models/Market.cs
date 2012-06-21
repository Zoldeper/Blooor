using Cirrious.MvvmCross.ViewModels;
using System;
using Ahwa.Attila.Core.Android.Interface;

namespace Ahwa.Attila.Core.Android.Models
{
    public class Market : DataClassBase
    {
        private double _Longitude = 0;

        public double Longitude
        {
            get { return _Longitude; }
            set { _Longitude = value; FirePropertyChanged("Longitude"); }
        }

        private double _Latitude = 0;

        public double Latitude
        {
            get { return _Latitude; }
            set { _Latitude = value; FirePropertyChanged("Latitude"); }
        }

        private string _MarketName;

        public string MarketName
        {
            get { return _MarketName; }
            set { _MarketName = value; FirePropertyChanged("MarketName"); }
        }

        public Market():base()
        {
            
        }

        public override void CloneFrom(object source)
        {
            var obj = source as Market;
            if (obj != null)
            {
                ID = obj.ID;
                Longitude = obj.Longitude;
                Latitude = obj.Latitude;
                MarketName = obj.MarketName;
            }            
        }
    }
}