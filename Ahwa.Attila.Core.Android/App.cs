using Ahwa.Attila.Core.Android.ApplicationObjects;
using Ahwa.Attila.Core.Android.Interface;
using Ahwa.Attila.Core.Android.Models;
using Cirrious.MvvmCross.Application;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.Interfaces.ViewModels;
using Cirrious.MvvmCross.Interfaces.Platform.Tasks;
using Cirrious.MvvmCross.Android.Platform.Tasks;
using Cirrious.MvvmCross.Android.Platform;


namespace Ahwa.Attila.Core.Android
{
    public class App : MvxApplication
        , IMvxServiceProducer<IMvxStartNavigation>
        , IMvxServiceProducer<IDataStore>
        , IMvxServiceProducer<IMvxViewModelLocatorAnalyser>
    {
        public App()
        {
            var startApplicationObject = new StartApplicationObject();            
            this.RegisterServiceInstance<IMvxStartNavigation>(startApplicationObject);
            MvxAndroidServiceProvider.Instance.RegisterServiceType<IMvxZXingBarCodeReaderTask, MvxZXingBarCodeReaderTask>();
            
            // set up the model
            var dataStore = new DataStore();
            this.RegisterServiceInstance<IDataStore>(dataStore);
        }
    }
}