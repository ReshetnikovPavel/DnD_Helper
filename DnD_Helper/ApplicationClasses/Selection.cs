using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Helper.ApplicationClasses
{
    internal class Selection
    {
        public string Property { get; }
        public object Value { get; }

        public Selection(string property, object value)
        {
            Property = property;
            Value = value;
        }
    }
}
