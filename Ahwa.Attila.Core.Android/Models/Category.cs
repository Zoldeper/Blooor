using Cirrious.MvvmCross.ViewModels;
using Ahwa.Attila.Core.Android.Interface;
using System;

namespace Ahwa.Attila.Core.Android.Models
{
    public class Category : DataClassBase
    {
        private string _CategoryName;

        public string CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; FirePropertyChanged(()=>this.CategoryName); }
        }

        public Category():base()
        {
        }

        public override void CloneFrom(object source)
        {
            var obj = source as Category;
            if (obj != null)
            {
                ID = obj.ID;
                CategoryName = obj.CategoryName;
            }            
        }

        public override string ToString()
        {
            return this.CategoryName;
        }
    }
}