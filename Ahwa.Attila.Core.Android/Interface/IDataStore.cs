using System.IO;
using Ahwa.Attila.Core.Android.Models;

namespace Ahwa.Attila.Core.Android.Interface
{
    public interface IDataStore 
    {
        void CreateObject<T>(T obj) where T : DataClassBase;
        void UpdateObject<T>(T obj) where T : DataClassBase;
        void DeleteObject<T>(string objID) where T : DataClassBase;
        T GetObject<T>(string objID) where T : DataClassBase;
        IObservableCollection<T> GetModelContainer<T>();
        string SaveImage(Stream fileStream);
        void DeleteImage(string fileName);
    }
}