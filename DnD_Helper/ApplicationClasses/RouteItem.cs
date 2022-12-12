using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Helper.ApplicationClasses
{
    internal class RouteItem : IHasRoute
    {
        private string prefix;
        public string Route { get; }
        public Func<bool> CanGo { get; }

        public RouteItem(string prefix, string route, Func<bool> goCondition)
        {
            Route = route;
            this.prefix = prefix;
            CanGo = goCondition;
        }

        public RouteItem(string prefix, string route)
            : this(prefix, route, () => true) { }

        public bool TryGo()
        {
            TriedToGo?.Invoke(this, EventArgs.Empty);
            if (!CanGo())
                return false;
            Go();
            return true;
        }

        private async void Go()
        {
            await Shell.Current.GoToAsync(prefix+Route);
        }

        public event EventHandler TriedToGo;
    }
}
