
using System;
using Ahwa.Attila.Core.Android.Interface;
using Ahwa.Attila.Core.Android.Models;
using Ahwa.Attila.Core.Android.ViewModels.BaseViewModels;
using Cirrious.MvvmCross.Commands;
using Cirrious.MvvmCross.Interfaces.Commands;

namespace Ahwa.Attila.Core.Android.ViewModels.ShoppingItemViewModels
{
    public abstract class BaseEditShoppingItemViewModel<T>: BaseEditObjectViewModel<ShoppingItem>
        where T : ShoppingItem, new()
    {
        private Category _SelectedCategory;
        public Category SelectedCategory
        {
            get { return DataStore.GetObject<Category>(Model.CategoryID); }
            set { Model.CategoryID = value.ID; FirePropertyChanged(() => SelectedCategory); }
        }

        public IObservableCollection<Category> Categories
        {
            get
            {
                var categories = DataStore.GetModelContainer<Category>();
                return categories;
            }
        }

        protected BaseEditShoppingItemViewModel(string id)
            : base(id)
        {                        
        }

        public IMvxCommand SelectCategoryCommand
        {
            get
            {
                return new MvxRelayCommand<Category>((category) =>
                {
                    Model.CategoryID = category.ID;
                });
                throw new NotImplementedException();
            }
        }            
    }
}