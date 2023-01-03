using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.App.ApplicationClasses
{
    class CharacterCreationNavigator : IModelNavigator
    {
        private RouteCollection routes;

        public CharacterCreationNavigator()
        {
            routes = new RouteCollection();
        }

        public void AddModel<TModel>() where TModel : BindableObject
        {
            routes.AddRoute(new RouteItem("///", typeof(TModel).Name));
        }

        public void GoToNextRoute(string currentRoute)
        {
            routes.GetNextAvailableRoute(currentRoute)?.TryGo();
        }
    }
}
