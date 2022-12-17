using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Helper.ApplicationClasses
{
    public interface IHasRoute
    {
        string Route { get; }
        Func<bool> CanGo { get; }

        bool TryGo();

        public event EventHandler TriedToGo;
    }
}
