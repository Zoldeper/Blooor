using System;
using System.Linq;

using Cirrious.MvvmCross.Converters;

namespace Ahwa.Attila.Core.Android.Converter
{
    public class StringReverseValueConverter : MvxBaseValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var stringValue = value as string;
            if (string.IsNullOrEmpty(stringValue))
                return string.Empty;
            return new string(stringValue.Reverse().ToArray());
        }
    }
}