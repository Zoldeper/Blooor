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
using Cirrious.MvvmCross.Commands;
using Ahwa.Attila.Core.Android.Models;
using Ahwa.Attila.Core.Android.ViewModels.BaseViewModels;
using Cirrious.MvvmCross.ShortNames;

namespace Ahwa.Attila.Core.Android.ViewModels.ProductViewModels
{
    public class DetailsProductViewModel: DetailsObjectViewModel<Product>
    {
        public DetailsProductViewModel(string id)
            : base(id)
        {            
        }

        public override MvxRelayCommand NavigateToEditViewModel()
        {
            return new MvxRelayCommand(() =>
            {
                RequestNavigate<EditProductViewModel>(new StringDict() { { "id", Model.ID } });
            });
        }

        public override Cirrious.MvvmCross.Interfaces.Commands.IMvxCommand DeleteCommand
        {
            get
            {
                DataStore.DeleteImage(Model.ImagePath);
                return base.DeleteCommand;
            }
        }
    }
}