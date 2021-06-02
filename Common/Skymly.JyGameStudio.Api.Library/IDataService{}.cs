using System;
using System.Collections.Generic;
using System.Text;

namespace Skymly.JyGameStudio.Api
{
    public interface IDataService<T> where T : class
    {
        IEnumerable<T> Get();
        T Get(Guid id);
        T Get(string id);
        T Delete();
        bool Delete(Guid id);
        bool Put(T obj);
        bool Post(T obj);
    }
}
