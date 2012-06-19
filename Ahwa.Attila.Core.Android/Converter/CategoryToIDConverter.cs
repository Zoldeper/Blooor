using System;
using Ahwa.Attila.Core.Android.Interface;
using Ahwa.Attila.Core.Android.Models;
using Cirrious.MvvmCross.Converters;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;

namespace Ahwa.Attila.Core.Android.Converter
{
    public class CategoryToIDConverter : MvxBaseValueConverter, IMvxServiceConsumer<IDataStore>
    {
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var dataStore = this.GetService<IDataStore>();
            return dataStore.GetObject<Category>((string)value).CategoryName;            
        }
    }
}