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
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Binding.Android.Target;
using Cirrious.MvvmCross.Android.Interfaces;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.Binding.Interfaces;
using Android;
using Ahwa.Attila.Core.Android.Models;

namespace Ahwa.Attila.Core.Android.Bindings
{
    public class SpinnerItemSourceBinding: MvxBaseAndroidTargetBinding, IMvxServiceConsumer<IMvxAndroidCurrentTopActivity>         
    {
        private readonly Spinner _spinner;
        private int _ItemLayoutID;
        
        public SpinnerItemSourceBinding(Spinner spinner, int itemLayoutID)
        {
            _spinner = spinner;
            _ItemLayoutID = itemLayoutID;
        }

        public override void SetValue(object value)
        {
            try
            {
                var context = this.GetService<IMvxAndroidCurrentTopActivity>().Activity;
                _spinner.Adapter = new ArrayAdapter<Category>(context, Resource.Layout.SimpleSpinnerItem, value as IList<Category>);
            }
            catch (Exception ex)
            {
            }
        }

        public override Cirrious.MvvmCross.Binding.Interfaces.MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.OneWay; }
        }

        public override Type TargetType
        {
            get { return typeof(IList<Category>); }
        }    
    }
}