using System.IO;
using Ahwa.Attila.Core.Android.Models;

namespace Ahwa.Attila.Core.Android.Interface
{
    public interface IDataStore 
    {
        //IObservableCollection<Market> Markets { get; }
        //void CreateMarket(Market market);
        //void UpdateMarket(Market market);
        //void DeleteMarket(string marketID);
        //Market GetMarket(string marketID);


        //IObservableCollection<Category> Categories { get; }
        //void CreateCategory(Category category);
        //void UpdateCategory(Category category);
        //void DeleteCategory(string categoryID);
        //Category GetCategory(string categoryID);

        void CreateObject<T>(T obj) where T : DataClassBase;
        void UpdateObject<T>(T obj) where T : DataClassBase;
        void DeleteObject<T>(string objID) where T : DataClassBase;
        T GetObject<T>(string objID) where T : DataClassBase;
        IObservableCollection<T> GetModelContainer<T>();
        string SaveImage(string fileName, Stream fileStream);
        void DeleteImage(string fileName);
    }
}