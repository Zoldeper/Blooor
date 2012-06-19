using System;
using Ahwa.Attila.Core.Android.Models;
using Cirrious.MvvmCross.Interfaces.Commands;
using Cirrious.MvvmCross.ShortNames;
using Cirrious.MvvmCross.Commands;
using Ahwa.Attila.Core.Android.ViewModels.BaseViewModels;

namespace Ahwa.Attila.Core.Android.ViewModels.CategoryViewModels
{
    public class DetailsCategoryViewModel : DetailsObjectViewModel<Category>
    {
        public DetailsCategoryViewModel(string id):base(id)
        {            
        }

        public override MvxRelayCommand NavigateToEditViewModel()
        {
            return new MvxRelayCommand(() =>
            {
                RequestNavigate<EditCategoryViewModel>(new StringDict() { { "id", Model.ID } });
            });
        }
    }
}