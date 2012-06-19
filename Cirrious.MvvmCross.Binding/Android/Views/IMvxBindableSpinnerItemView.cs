

namespace Cirrious.MvvmCross.Binding.Android.Views
{
    public interface IMvxBindableSpinnerItemView
    {
        int TemplateId { get; }
        void BindTo(object source);
    }
}