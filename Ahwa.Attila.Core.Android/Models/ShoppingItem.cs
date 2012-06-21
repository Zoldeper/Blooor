
using Cirrious.MvvmCross.ViewModels;

namespace Ahwa.Attila.Core.Android.Models
{
    public class ShoppingItem : DataClassBase
    {
        private string _ShoppingItemName;

        public string ShoppingItemName
        {
            get { return _ShoppingItemName; }
            set { _ShoppingItemName = value; FirePropertyChanged(() => ShoppingItemName); }
        }
        

        private string _CategoryID;

        public string CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; FirePropertyChanged(() => CategoryID); }
        }

        private float? _Quantity;

        public float? Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; FirePropertyChanged(() => Quantity); }
        }

        private bool _IsPurchased;

        public bool IsPurchased
        {
            get { return _IsPurchased; }
            set { _IsPurchased = value; FirePropertyChanged(() => IsPurchased); }
        }

        private string _PurchasedProduct;
        /// <summary>
        /// ProductID
        /// </summary>
        public string PurchasedProduct
        {
            get { return _PurchasedProduct; }
            set { _PurchasedProduct = value; FirePropertyChanged(() => PurchasedProduct); }
        }

        private string _PurchaseLocation;
        /// <summary>
        /// MarketID
        /// </summary>
        public string PurchaseLocation
        {
            get { return _PurchaseLocation; }
            set { _PurchaseLocation = value; FirePropertyChanged(() => PurchaseLocation); }
        }

        private float _PurchasePrice;
        public float PurchasePrice
        {
            get { return _PurchasePrice; }
            set { _PurchasePrice = value; FirePropertyChanged(() => PurchasePrice); }
        }

        public override void CloneFrom(object source)
        {
            var obj = source as ShoppingItem;
            if (obj != null)
            {
                this.ID = obj.ID;
                this.CategoryID = obj.CategoryID;
                this.ShoppingItemName = obj.ShoppingItemName;
                this.Quantity = obj.Quantity;
                this.IsPurchased = obj.IsPurchased;
                this.PurchasedProduct = obj.PurchasedProduct;
                this.PurchaseLocation = obj.PurchaseLocation;
                this.PurchasePrice = obj.PurchasePrice;
            }

        }
    }
}