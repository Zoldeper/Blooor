using Cirrious.MvvmCross.ViewModels;

namespace Ahwa.Attila.Core.Android.ViewModels
{
    public class SimpleTextPropertyViewModel : MvxViewModel
    {
        private string _TextValue;
        public string TextValue
        {
            get { return _TextValue; }
            set { _TextValue = value; FirePropertyChanged("TextValue"); }
        }

        public SimpleTextPropertyViewModel()
        {            
        }
    }
}