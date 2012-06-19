using Cirrious.MvvmCross.ViewModels;
using System;

namespace Ahwa.Attila.Core.Android.Models
{
    public class Merchandise : MvxNotifyPropertyChanged
    {
        private int _MerchandiseID;

        public int MerchandiseID
        {
            get { return _MerchandiseID; }
            set { _MerchandiseID = value; }
        }

        private int _ProductID;

        public int ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }

        private int _MarketID;

        public int MarketID
        {
            get { return _MarketID; }
            set { _MarketID = value; }
        }

        private double _LastRecordedPrice;

        public double LastRecordedPrice
        {
            get { return _LastRecordedPrice; }
            set { _LastRecordedPrice = value; }
        }
    }
}