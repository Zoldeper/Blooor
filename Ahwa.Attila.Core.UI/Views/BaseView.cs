using Cirrious.MvvmCross.Binding.Android.Views;
using Cirrious.MvvmCross.Interfaces.ViewModels;

namespace Ahwa.Attila.UI.Android.Views
{
    public abstract class BaseView<TViewModel>
        : MvxBindingActivityView<TViewModel>
        where TViewModel : class, IMvxViewModel
    {        
    }
}