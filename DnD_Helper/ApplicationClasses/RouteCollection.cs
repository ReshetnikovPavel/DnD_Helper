using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Helper.ApplicationClasses
{
    internal class RouteCollection
    {
        private Dictionary<IHasRoute, int> routes;

        public RouteCollection(IHasRoute[] routes)
        {
            this.routes = routes
                .Select((route, index) => (route, index))
                .ToDictionary(pair => pair.route, pair => pair.index);
        }

        public IHasRoute GetNext(string route)
        {
            var index = routes.FirstOrDefault(pair => pair.Key.Route == route).Value;
            return routes.Skip(index + 1)
                .FirstOrDefault(pair => pair.Key.CheckCondition())
                .Key;
        }
    }
}
