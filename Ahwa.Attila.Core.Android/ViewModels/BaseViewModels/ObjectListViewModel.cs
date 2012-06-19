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
    public abstract class ObjectListViewModel<T> : BaseViewModel where T : DataClassBase
    {
        public ObjectListViewModel()
            : base(){}
        
        public IObservableCollection<T> Models { get { return DataStore.GetModelContainer<T>(); } }

        public IMvxCommand SelectCommand
        {
            get
            {
                return NavigateToDetailsViewModel();
            }
        }

        public IMvxCommand AddCommand
        {
            get
            {
                return NavigateToNewViewModel();
            }
        }

        public abstract IMvxCommand NavigateToDetailsViewModel();
        public abstract IMvxCommand NavigateToNewViewModel();
    }
}