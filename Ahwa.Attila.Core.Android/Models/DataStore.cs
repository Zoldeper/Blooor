using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Linq;
using System.Xml.Serialization;
using Ahwa.Attila.Core.Android.Interface;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.Localization;
using Cirrious.MvvmCross.Interfaces.Platform;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Android.Graphics;
using Cirrious.MvvmCross.Android.Platform;
using Cirrious.MvvmCross.Android.Interfaces;

namespace Ahwa.Attila.Core.Android.Models
{
    public class DataStore : Interface.IDataStore, IMvxServiceConsumer<IMvxSimpleFileStoreService>, IMvxServiceConsumer<IMvxResourceLoader>
    {

        private const string XmlDirectoryName = "Xml";
        private const string ImageDirectoryName = "Image";

        private const string XmlFileName = "{0}.xml";
        private const string ImageFileName = "{0}.jpg";
        
        private Dictionary<Type, object> containers = new Dictionary<Type, object>();        

        public DataStore()
        {
            var fileService = this.GetService<IMvxSimpleFileStoreService>();
            fileService.EnsureFolderExists(XmlDirectoryName);
            fileService.EnsureFolderExists(ImageDirectoryName);


            containers.Add(typeof(Category), new SimpleObservableCollection<Category>(new List<Category>()));
            containers.Add(typeof(Market), new SimpleObservableCollection<Market>(new List<Market>()));
            containers.Add(typeof(Product), new SimpleObservableCollection<Product>(new List<Product>()));
            containers.Add(typeof(ShoppingItem), new SimpleObservableCollection<ShoppingItem>(new List<ShoppingItem>()));
            Load<Market>();
            Load<Category>();
            Load<Product>();
            Load<ShoppingItem>();
        }

        private void Load<T>()
        {
            var fileService = this.GetService<IMvxSimpleFileStoreService>();
            var fileName = System.IO.Path.Combine(XmlDirectoryName, string.Format(XmlFileName, typeof(T).Name));
            if (!fileService.TryReadBinaryFile(fileName, (inputStream) => { return LoadFrom<T>(inputStream); }))
            {
                var resourceLoader = this.GetService<IMvxResourceLoader>();
                resourceLoader.GetResourceStream(fileName, (inputStream) => LoadFrom<T>(inputStream));                
            }
        }

        private bool LoadFrom<T>(Stream inputStream)
        {
            try
            {
                var loadedData = XDocument.Load(inputStream);
                if (loadedData.Root == null)
                    return false;

                using (var reader = loadedData.Root.CreateReader())
                {
                    var list = (List<T>)new XmlSerializer(typeof(List<T>)).Deserialize(reader);
                    containers[typeof(T)] = new SimpleObservableCollection<T>(list);
                    return true;
                }
            }
            catch (ThreadAbortException)
            {
                throw;
            }
            catch (Exception exception)
            {
                TraceHelper.Trace("Problem loading list {0}", exception.ToLongString());
                return false;
            }
        }

        private void Save<T>()
        {
            try
            {
            var fileService = this.GetService<IMvxSimpleFileStoreService>();

            var fileName = System.IO.Path.Combine(XmlDirectoryName, string.Format(XmlFileName, typeof(T).Name));
            fileService.WriteFile(fileName, (stream) =>
            {
                var serializer = new XmlSerializer(typeof(List<T>));
                serializer.Serialize(stream, GetModelContainer<T>().ToList());
            });
            }
            catch (ThreadAbortException)
            {
                throw;
            }
            catch (Exception exception)
            {
                TraceHelper.Trace("Problem saving list {0}", exception.ToLongString());                
            }
        }      

        #region Object
        public void CreateObject<T>(T obj) where T : DataClassBase
        {
            GetModelContainer<T>().Add(obj);
            Save<T>();
        }
        public void UpdateObject<T>(T obj) where T : DataClassBase 
        {
            var objectToUpdate = GetObject<T>(obj.ID);
            if (objectToUpdate != null)
            {
                objectToUpdate.CloneFrom(obj);
                Save<T>();
            }
        }
        public void DeleteObject<T>(string id) where T : DataClassBase
        {
            var objectToBeDeleted = GetObject<T>(id);
            if (objectToBeDeleted != null)
            {
                GetModelContainer<T>().Remove(objectToBeDeleted);
                Save<T>();
            }
        }
        public T GetObject<T>(string id) where T : DataClassBase
        {
            return GetModelContainer<T>().FirstOrDefault(c => c.ID == id);
        }

        public IObservableCollection<T> GetModelContainer<T>() 
        {
            return (IObservableCollection<T>)containers[typeof(T)];
        }
        #endregion

        public string SaveImage(Stream stream)
        {
            try
            {
                var fileName = string.Format(ImageFileName, Guid.NewGuid().ToString()); 
                var fileService = this.GetService<IMvxSimpleFileStoreService>();
                fileName = System.IO.Path.Combine(ImageDirectoryName, fileName);
                fileService.WriteFile(fileName, (fStream) =>
                {
                    stream.CopyTo(fStream);
                });
                return fileName;
            }
            catch (ThreadAbortException)
            {
                throw;
            }
            catch (Exception exception)
            {
                TraceHelper.Trace("Problem saving list {0}", exception.ToLongString());
                return "";
            }
        }
        public void DeleteImage(string fileName)
        {
            try
            {
                var fileService = this.GetService<IMvxSimpleFileStoreService>();
                fileService.DeleteFile(fileName);
            }
            catch { }
        }
        
    }
}