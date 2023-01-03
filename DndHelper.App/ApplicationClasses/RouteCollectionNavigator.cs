using DndHelper.Domain.Dnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.App.ApplicationClasses
{
    public class RouteCollectionNavigator : IModelNavigator
    {
        private IHasRouteCollection routes;

        public RouteCollectionNavigator(IHasRouteCollection routes)
        {
            this.routes = routes;
        }

        public void AddModel<TModel>() where TModel : BindableObject
        {
            routes.AddRoute(new RouteItem("///", typeof(TModel).Name));
        }

        public bool TryGoToNextRoute(string currentRoute)
        {
            var nextRoute = routes.GetNextAvailableRoute(currentRoute);
            if (nextRoute == null)
                return false;
            nextRoute.TryGo();
            return true;
        }
    }
}
