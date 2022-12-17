using DnD_Helper.ViewModels;
using DndHelper.Domain.Dnd;
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
        private const string CharacterSheetRoute = nameof(CharacterSheetViewModel);

        public CharacterCreationNavigator(IHasRouteCollection routes)
        {
            this.routes = routes;
            MessagingCenter.Subscribe<BindableObject, string>(
                this, MessageTypes.PageCompleted.ToString(), 
                (BindableObject sender, string currentRoute) => GoToNextRoute(currentRoute));
            
        }

        public void AddModel<TModel>() where TModel : BindableObject
        {
            routes.AddRoute(new RouteItem("///", typeof(TModel).Name));
        }

        public void GoToNextRoute(string currentRoute)
        {
            routes.GetNextAvailableRoute(currentRoute)?.TryGo();
        }

        public async void GoToCharacterSheet(Character character)
        {
            await Shell.Current.GoToAsync($"/{CharacterSheetRoute}");
        }
    }
}
