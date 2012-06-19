using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ahwa.Attila.Core.Android.Interface;

namespace Ahwa.Attila.Core.Android.Models
{
    public class SimpleObservableCollection<T>
        : ObservableCollection<T>
        , IObservableCollection<T>
    {
        public SimpleObservableCollection(List<T> source)
            : base(source)
        {
        }
    }
}