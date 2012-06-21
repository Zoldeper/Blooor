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
using Cirrious.MvvmCross.Interfaces.Commands;
using Cirrious.MvvmCross.Commands;

namespace Ahwa.Attila.Core.Android.ViewModels.ShoppingItemViewModels
{
    public class ShoppingItemListViewModel: ObjectListViewModel<ShoppingItem>
    {
        public ShoppingItemListViewModel()
            : base()
        {
            
        }
        
        public override IMvxCommand NavigateToDetailsViewModel()
        {
            return new MvxRelayCommand<ShoppingItem>((model) => RequestNavigate<DetailsShoppingItemViewModel>(new { id = model.ID }));
        }
        public override IMvxCommand NavigateToNewViewModel()
        {
            return new MvxRelayCommand(()=>RequestNavigate<NewShoppingItemViewModel>());
        }
    }
}