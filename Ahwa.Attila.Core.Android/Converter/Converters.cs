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
using Cirrious.MvvmCross.Converters;

namespace Ahwa.Attila.Core.Android.Converter
{
    public class Converters
    {
        public readonly StringLengthValueConverter StringLength = new StringLengthValueConverter();
        public readonly StringReverseValueConverter StringReverse = new StringReverseValueConverter();
        public readonly FilePathConverter FilePath = new FilePathConverter();
        public readonly CategoryToIDConverter CategoryToID = new CategoryToIDConverter();        
    }
}