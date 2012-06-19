using Cirrious.MvvmCross.ViewModels;

namespace Ahwa.Attila.Core.Android.Models
{
    public class LikelyProductPurchaseOrder : MvxNotifyPropertyChanged
    {
        private int _ProcuctID;
        public int ProductID
        {
            get { return _ProcuctID; }
            set { _ProcuctID = value; }
        }

        private int _FollowingPruchasedProductID;
        public int FollowingPruchasedProductID
        {
            get { return _FollowingPruchasedProductID; }
            set { _FollowingPruchasedProductID = value; }
        }

        private int _MarketID;
        public int MarketID
        {
            get { return _MarketID; }
            set { _MarketID = value; }
        }

        private int _OccurrenceCount;
        public int OccurrenceCount
        {
            get { return _OccurrenceCount; }
            set { _OccurrenceCount = value; }
        }
    }
}