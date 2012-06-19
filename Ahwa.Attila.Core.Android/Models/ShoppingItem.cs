
using Cirrious.MvvmCross.ViewModels;

namespace Ahwa.Attila.Core.Android.Models
{
    public class ShoppingItem : MvxNotifyPropertyChanged
    {
        private int _ShoppingItemID;

        public int ShoppingItemID
        {
            get { return _ShoppingItemID; }
            set { _ShoppingItemID = value; }
        }

        private int _CategoryID;

        public int CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }

        private double _Quantity;

        public double Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }

        private bool _IsPurchased;

        public bool IsPurchased
        {
            get { return _IsPurchased; }
            set { _IsPurchased = value; }
        }

        private int _PurchasedProduct;
        /// <summary>
        /// ProductID
        /// </summary>
        public int PurchasedProduct
        {
            get { return _PurchasedProduct; }
            set { _PurchasedProduct = value; }
        }

        private int _PurchaseLocation;
        /// <summary>
        /// MarketID
        /// </summary>
        public int PurchaseLocation
        {
            get { return _PurchaseLocation; }
            set { _PurchaseLocation = value; }
        }

        private double _PurchasePrice;
        public double PurchasePrice
        {
            get { return _PurchasePrice; }
            set { _PurchasePrice = value; }
        }
    }
}