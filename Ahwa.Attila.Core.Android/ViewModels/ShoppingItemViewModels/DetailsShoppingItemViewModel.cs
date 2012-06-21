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
using Ahwa.Attila.Core.Android.ViewModels.BaseViewModels;
using Cirrious.MvvmCross.Commands;
using Cirrious.MvvmCross.ShortNames;

namespace Ahwa.Attila.Core.Android.ViewModels.ShoppingItemViewModels
{
    public class DetailsShoppingItemViewModel: DetailsObjectViewModel<ShoppingItem>
    {
        public DetailsShoppingItemViewModel(string id)
            : base(id)
        {            
        }

        public override MvxRelayCommand NavigateToEditViewModel()
        {
            return new MvxRelayCommand(() =>
            {
                RequestNavigate<EditShoppingItemViewModel>(new StringDict() { { "id", Model.ID } });
            });
        }

        public override Cirrious.MvvmCross.Interfaces.Commands.IMvxCommand DeleteCommand
        {
            get
            {
                return base.DeleteCommand;
            }
        }
    }
}