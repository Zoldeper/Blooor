using Cirrious.MvvmCross.ViewModels;
namespace Ahwa.Attila.Core.Android.Models
{
    public class Product: DataClassBase
    {
        private string _CategoryID;
        public string CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; FirePropertyChanged("CategoryID"); }
        }

        private string _BarCode;
        public string BarCode
        {
            get { return _BarCode; }
            set { _BarCode = value; FirePropertyChanged("BarCode"); }
        }

        private string _ImagePath;
        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; FirePropertyChanged("ImagePath"); }
        }

        private string _ProductName;
        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; FirePropertyChanged("ProductName"); }
        }

        public Product():base()
        {            
        }

        public override void CloneFrom(object source)
        {
            var obj = source as Product;
            if (source != null)
            {
                ID = obj.ID;
                BarCode = obj.BarCode;
                ImagePath = obj.ImagePath;
                ProductName = obj.ProductName;
                CategoryID = obj.CategoryID;
            }            
        }
    }
}