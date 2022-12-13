using DnD_Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Helper.ApplicationClasses
{
    public class CreationStateManager : IStateManager<string, object>
    {
        private Dictionary<string, object> state = new Dictionary<string, object>();

        public object GetValue(string key)
        {
            return state[key];
        }

        public void SetValue(string key, object value)
        {
            if (!state.ContainsKey(key))
                state.Add(key, value);
            else
                state[key] = value;
        }
    }
}

