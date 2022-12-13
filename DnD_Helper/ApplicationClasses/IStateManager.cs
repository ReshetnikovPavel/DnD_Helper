using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Helper.ApplicationClasses
{
    public interface IStateManager<TKey, TValue>
    {
        public TValue GetValue(TKey key);
        void SetValue(TKey key, TValue value);
    }
}
