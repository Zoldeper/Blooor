using System.Collections.Generic;
using System.Collections.Specialized;

namespace Ahwa.Attila.Core.Android.Interface
{
    public interface IObservableCollection<T>
        : IList<T>
        , INotifyCollectionChanged
    {
    }
}