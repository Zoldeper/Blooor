using Android.Content;
using Cirrious.MvvmCross.Application;
using Cirrious.MvvmCross.Binding.Android;
using Ahwa.Attila.Core.Android;
using System.Collections.Generic;
using Ahwa.Attila.Core.Android.Converter;
using System;
using Cirrious.MvvmCross.Binding.Bindings.Target.Construction;
using Ahwa.Attila.Core.Android.Models;
using Ahwa.Attila.Core.Android.Bindings;
using Cirrious.MvvmCross.Binding.Android.Views;
using Android.Widget;
using Ahwa.Attila.Core.Android.Interface;

namespace Ahwa.Attila.UI.Android
{
    public class Setup
        : MvxBaseAndroidBindingSetup
    {
        public Setup(Context applicationContext)
            : base(applicationContext)
        {
        }

        protected override MvxApplication CreateApp()
        {
            return new App();
        }

        protected override IEnumerable<Type> ValueConverterHolders
        {
            get { return new[] { typeof(Converters) }; }
        }

        protected override void FillTargetFactories(Cirrious.MvvmCross.Binding.Interfaces.Bindings.Target.Construction.IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);
            registry.RegisterFactory(new MvxCustomBindingFactory<MvxBindableSpinner>("SelectedItem", (spinner) => new SpinnerSelectedItemBinding<Category>(spinner)));            
        }
    }
}