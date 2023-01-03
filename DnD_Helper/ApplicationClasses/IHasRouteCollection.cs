﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Helper.ApplicationClasses
{
    public interface IHasRouteCollection
    {
        public void AddRoute(IHasRoute route);
        public IHasRoute GetNextAvailableRoute(string currentRoute);
    }
}
