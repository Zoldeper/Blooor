using System;
using System.Collections.Generic;
using System.Text;

using Cirrious.MvvmCross.Interfaces.Platform.Tasks;
using Cirrious.MvvmCross.ExtensionMethods;
using Android.App;
using Cirrious.MvvmCross.Android.Interfaces;

namespace Cirrious.MvvmCross.Android.Platform.Tasks
{
    public class MvxZXingBarCodeReaderTask : MvxAndroidTask, IMvxZXingBarCodeReaderTask        
    {
        Action<string> _ProcessReadBarCode;

        public void ReadBarCode(Action<string> processReadBarCode)
        {
            _ProcessReadBarCode = processReadBarCode;

            MvxZXingIntentIntegrator integrator = new MvxZXingIntentIntegrator(this.GetService<IMvxAndroidCurrentTopActivity>().Activity, StartActivityForResult);            
            integrator.InitiateScan();            
        }

        protected override bool ProcessMvxIntentResult(Interfaces.MvxIntentResultEventArgs result)
        {
            MvxZXingIntentResult scanResult = MvxZXingIntentIntegrator.ParseActivityResult(result.RequestCode, result.ResultCode, result.Data);
            if (scanResult != null && _ProcessReadBarCode != null)
            {
                _ProcessReadBarCode(scanResult.Contents);
                return true;
            }
            return base.ProcessMvxIntentResult(result);
        }
    }
}