using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Helper.ApplicationClasses
{
    internal class RouteItem : IHasRoute
    {
        public string Route { get; }
        public Func<bool> CheckCondition { get; }
        
        public RouteItem(string route, Func<bool> condition)
        {
            Route = route;
            CheckCondition = condition;
        }

        public RouteItem(string route)
        {
            Route = route;
            CheckCondition = () => true;
        }

        public async void Go()
        {
            if (!CheckCondition())
                return;
            await Shell.Current.GoToAsync($"///{Route}");
        }
    }
}
