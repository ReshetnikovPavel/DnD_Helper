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
        public Func<bool> CheckCondition { get; }

        public RouteItem(string prefix, string route, Func<bool> condition)
        {
            Route = route;
            this.prefix = prefix;
            CheckCondition = condition;
        }

        public RouteItem(string prefix, string route)
            : this(prefix, route, () => true) { }

        public bool TryGo()
        {
            TriedToGo?.Invoke(this, EventArgs.Empty);
            if (!CheckCondition())
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
