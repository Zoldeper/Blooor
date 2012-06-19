using System;
using Cirrious.MvvmCross.Converters;

namespace Ahwa.Attila.Core.Android.Converter
{
    public class StringLengthValueConverter : MvxBaseValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var stringValue = value as string;
            if (string.IsNullOrEmpty(stringValue))
                return 0;
            else
                return stringValue.Length;
        }
    }
}