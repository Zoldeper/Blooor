using Cirrious.MvvmCross.ViewModels;
using System;

namespace Ahwa.Attila.Core.Android.Models
{
    public abstract class DataClassBase : MvxNotifyPropertyChanged
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
        public abstract void CloneFrom(object source);
    }
}