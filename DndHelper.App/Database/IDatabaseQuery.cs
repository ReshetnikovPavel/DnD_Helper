using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.App.Database
{
    public interface IDatabaseQuery
    {
        IDatabaseQuery Child(string name);
        Task<T> GetAsync<T>();
        Task PutAsync<T>(T obj);
        Task<IEnumerable<T>> GetManyAsync<T>();
    }
}
