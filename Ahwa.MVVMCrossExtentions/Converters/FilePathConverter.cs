using System;
using Cirrious.MvvmCross.Android.Interfaces;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using System.IO;
using Android.Widget;
using AndroNet = Android.Net;


namespace Cirrious.MvvmCross.Converters
{
    public class FilePathConverter : MvxBaseValueConverter, IMvxServiceConsumer<IMvxAndroidCurrentTopActivity>
    {
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var activity = this.GetService<IMvxAndroidCurrentTopActivity>().Activity;    
            string path =Path.Combine(activity.FilesDir.Path, (string)value );
            return AndroNet.Uri.Parse(path);
        }

    }
}