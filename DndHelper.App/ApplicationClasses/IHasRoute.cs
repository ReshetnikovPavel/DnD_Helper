using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.App.ApplicationClasses
{
    public interface IHasRoute
    {
        string Route { get; }
        Func<bool> CanGo { get; }

        bool TryGo();

        public event EventHandler TriedToGo;
    }
}
