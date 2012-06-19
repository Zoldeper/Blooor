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
using Cirrious.MvvmCross.Interfaces.Commands;
using Ahwa.Attila.Core.Android.Interface;
using Cirrious.MvvmCross.Commands;
using Ahwa.Attila.Core.Android.Models;
using Ahwa.Attila.Core.Android.ViewModels.BaseViewModels;

namespace Ahwa.Attila.Core.Android.ViewModels.CategoryViewModels
{
    public class CategoryListViewModel: ObjectListViewModel<Category>
    {
        public CategoryListViewModel():base ()
        {
            
        }
        
        public override IMvxCommand NavigateToDetailsViewModel()
        {
            return new MvxRelayCommand<Category>((model) => RequestNavigate<DetailsCategoryViewModel>(new { id = model.ID }));
        }
        public override IMvxCommand NavigateToNewViewModel()
        {
            return new MvxRelayCommand(()=>RequestNavigate<NewCategoryViewModel>());
        }
    }
}