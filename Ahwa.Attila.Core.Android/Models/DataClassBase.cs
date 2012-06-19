using Cirrious.MvvmCross.ViewModels;
using System;

namespace Ahwa.Attila.Core.Android.Models
{
    public class DataClassBase : MvxNotifyPropertyChanged
    {
        private string _ID;
        public string ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }

        public DataClassBase()
        {
            ID = Guid.NewGuid().ToString();
        }
        public virtual void CloneFrom(object source) { throw new NotImplementedException("Verify your source object type! The one you passed is not  suitable!"); }    
    }
}