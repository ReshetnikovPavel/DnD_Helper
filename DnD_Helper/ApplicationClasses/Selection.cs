using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Helper.ApplicationClasses
{
    internal class Selection
    {
        public string Type { get; }
        public string Value { get; }

        public Selection(string type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
