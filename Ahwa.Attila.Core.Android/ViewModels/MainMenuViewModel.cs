using System;
using System.Collections.Generic;

using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Interfaces.Commands;
using Cirrious.MvvmCross.Commands;

namespace Ahwa.Attila.Core.Android.ViewModels
{
    public class MainMenuViewModel:MvxViewModel
    {
        public List<Type> Items { get; set; }

        public MainMenuViewModel()
        {
            Items = new List<Type>()
                      {
                          typeof(SimpleTextPropertyViewModel)
                      };
        }

        public IMvxCommand ShowItemCommand
        {
            get
            {
                return new MvxRelayCommand<Type>((type) => this.RequestNavigate(type));
            }
        }
    }
}