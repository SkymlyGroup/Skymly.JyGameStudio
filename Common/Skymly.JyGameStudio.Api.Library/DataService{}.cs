using System;
using System.Collections.Generic;
using System.Text;

namespace Skymly.JyGameStudio.Api
{
    public abstract class DataService<T> : IDataService<T> where T : class
    {
        public DataService()
        {
        }

        public string BaseUrl { get; set; }

        public T Delete()
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Get()
        {
            throw new NotImplementedException();
        }

        public T Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public T Get(string id)
        {
            throw new NotImplementedException();
        }

        public bool Post(T obj)
        {
            throw new NotImplementedException();
        }

        public bool Put(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
