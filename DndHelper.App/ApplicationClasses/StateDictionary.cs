using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.App.ApplicationClasses
{
    class StateDictionary<TKey, TValue> : IStateManager<TKey, TValue>
    {
        private Dictionary<TKey, TValue> state = new Dictionary<TKey, TValue>();

        public TValue GetValue(TKey key)
        {
            return state[key];
        }

        public void SetValue(TKey key, TValue value)
        {
            if (!state.ContainsKey(key))
                state.Add(key, value);
            else
                state[key] = value;
        }
    }

}

