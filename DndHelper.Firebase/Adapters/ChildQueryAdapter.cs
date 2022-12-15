using DndHelper.App.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.Firebase.Adapters
{
    public class ChildQueryAdapter : IDatabaseQuery
    {
        ChildQuery childQuery;
        public ChildQueryAdapter(ChildQuery childQuery) 
        {
            this.childQuery = childQuery;
        }
        public IDatabaseQuery Child(string name)
        {
            return new ChildQueryAdapter(childQuery.Child(name));
        }

        public Task<T> GetAsync<T>()
        {
            return childQuery.OnceSingleAsync<T>();
        }

        public Task PutAsync<T>(T obj)
        {
            return childQuery.PutAsync(obj);
        }
    }
}
