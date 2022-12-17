using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Helper.ApplicationClasses
{
    public class CharacterCreationNavigator : IModelNavigator
    {
        private IHasRouteCollection routes;

        public CharacterCreationNavigator(IHasRouteCollection routes)
        {
            this.routes = routes;
        }

        public void AddModel<TModel>() where TModel : BindableObject
        {
            routes.AddRoute(new RouteItem("///", typeof(TModel).Name));
        }

        public void GoToNextRoute(string currentRoute)
        {
            routes.GetNextAvailableRoute(currentRoute)?.TryGo();
        }

        public async void TryGoToCharacterSheet()
        {
            await Shell.Current.DisplayAlert("Не бывать твоим желаниям, друг", "",
            "Да что же это");
        }
    }
}
