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
using Cirrious.MvvmCross.Interfaces.Commands;
using Cirrious.MvvmCross.Commands;

namespace Ahwa.Attila.Core.Android.ViewModels.BaseViewModels
{
    public abstract class DetailsObjectViewModel<T> : BaseViewModel where T : DataClassBase
    {
        private T _model;
        public T Model
        {
            get { return _model; }
            private set { _model = value; FirePropertyChanged("Model"); }
        }

        public DetailsObjectViewModel(string id)
        {
            Model = DataStore.GetObject<T>(id);
        }

        public IMvxCommand EditCommand
        {
            get
            {
                return NavigateToEditViewModel();
            }
        }

        public virtual IMvxCommand DeleteCommand
        {
            get
            {
                return new MvxRelayCommand(() =>
                {
                    try
                    {
                        DataStore.DeleteObject<T>(_model.ID);
                        RequestClose(this);
                    }
                    catch (Exception exception)
                    {
                        #warning TODO - how to send error messages?
                    }
                });
            }
        }

        public abstract MvxRelayCommand NavigateToEditViewModel();
    }
}