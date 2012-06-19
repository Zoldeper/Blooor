using System;
using Android.App;

namespace Cirrious.MvvmCross.Interfaces.Platform.Tasks
{
    public interface IMvxZXingBarCodeReaderTask
    {
        void ReadBarCode(Action<string> processReadBarCode);
    }
}