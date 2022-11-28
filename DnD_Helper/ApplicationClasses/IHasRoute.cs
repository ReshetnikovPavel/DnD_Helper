using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Helper.ApplicationClasses
{
    internal interface IHasRoute
    {
        string Route { get; }
        Func<bool> CheckCondition { get; }

        void Go();
    }
}
