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

        public IHasRoute GetNextAvailableRoute(string currentRoute)
        {
            var index = IndexOf(currentRoute);
            return routes
                .Skip(index + 1)
                .FirstOrDefault(pair => pair.Key.CanGo())
                .Key;
        }

        private int IndexOf(string route)
        {
            try
            {
                return routes.First(pair => pair.Key.Route == route).Value;
            }
            catch(InvalidOperationException e)
            {
                throw new InvalidOperationException("Given route does not exist", e);
            }
        }
    }
}
