using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Ahwa.Attila.Core.Android.Models;
using Ahwa.Attila.Core.Android.Interface;
using Cirrious.MvvmCross.Interfaces.Commands;
using Cirrious.MvvmCross.Commands;

namespace Ahwa.Attila.Core.Android.ViewModels.BaseViewModels
{
    public abstract class BaseEditObjectViewModel<T> : BaseViewModel where T : DataClassBase, new()
    {
        private T _model;
        public T Model
        {
            get { return _model; }
            private set { _model = value; FirePropertyChanged("Model"); }
        }

        public abstract IMvxCommand SaveCommand { get; }

        protected BaseEditObjectViewModel(string id)
        {
            Model = new T();
            if (id != null)
            {
                var original = DataStore.GetObject<T>(id);
                Model.CloneFrom(original);
            }
        }

        protected void Update()
        {
            DataStore.UpdateObject<T>(Model);
        }

        protected void AddNew()
        {
            DataStore.CreateObject<T>(Model);
        }

        
    }

}