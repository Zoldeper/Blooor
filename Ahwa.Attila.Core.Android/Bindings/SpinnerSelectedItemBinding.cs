using System;
using Android.Widget;
using Cirrious.MvvmCross.Binding.Android;
using Cirrious.MvvmCross.Binding.Android.Target;
using Cirrious.MvvmCross.Binding.Interfaces;
using Cirrious.MvvmCross.Binding.Android.Views;

namespace Ahwa.Attila.Core.Android.Bindings
{
    public class SpinnerSelectedItemBinding<T> : MvxBaseAndroidTargetBinding
    {
        private readonly MvxBindableSpinner _spinner;
        private T _currentValue;

        public SpinnerSelectedItemBinding(MvxBindableSpinner spinner)
        {
            _spinner = spinner;
            _spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(_spinner_ItemSelected);
        }

        void _spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var newValue = (_spinner.SelectedItem as MvxJavaContainer).Object;
            if (!((T)newValue).Equals(_currentValue))
            {
                FireValueChanged(newValue);
            }
        }

        public override void SetValue(object value)
        {
            if (!((T)value).Equals(_currentValue))
            {
                _currentValue = (T)value;
                _spinner.SetSelection(_spinner.Adapter.GetPosition(value));
            }
        }

        public override Cirrious.MvvmCross.Binding.Interfaces.MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.TwoWay; }
        }

        public override Type TargetType
        {
            get { return typeof(T); }
        }    
    }
}