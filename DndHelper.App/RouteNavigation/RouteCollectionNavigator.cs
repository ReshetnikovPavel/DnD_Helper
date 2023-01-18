﻿using DndHelper.App.ApplicationClasses;

namespace DndHelper.App.RouteNavigation
{
    public class RouteCollectionNavigator : IModelNavigator
    {
        private IHasRouteCollection routes;

        public RouteCollectionNavigator(IHasRouteCollection routes)
        {
            this.routes = routes;
        }

        public void AddModel<TModel>(Func<bool> goCondition) where TModel : BindableObject
        {
            routes.AddRoute(new RouteItem("///", typeof(TModel).Name, goCondition));
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
