using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.App.ApplicationClasses
{
    public interface IStateManager<TKey, TValue>
    {
        public TValue GetValue(TKey key);
        public bool HasKey(TKey key);
        void SetValue(TKey key, TValue value);
    }
}
