
using Android.App;
using Cirrious.MvvmCross.Android.Views;

namespace Ahwa.Attila.UI.Android
{
    [Activity(Label = "Ahwa.Attila.UI.Android", Theme = "@android:style/Theme.Black.NoTitleBar", MainLauncher = true, Icon = "@drawable/icon", NoHistory = true)]
    public class SplashScreenActivity : MvxBaseSplashScreenActivity
    {
        public SplashScreenActivity()
            : base(Resource.Layout.SplashScreen)
        {           
        }
    }
}

