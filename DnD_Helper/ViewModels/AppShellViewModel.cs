using DnD_Helper.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Helper.ViewModels
{
    public class AppShellViewModel : BindableObject
    {
        private RouteCollection routes;
        private IStateManager<string, object> stateManager;
        
        public AppShellViewModel()
        {
            this.stateManager = new CreationStateManager();
            InitRoutes();
            MessagingCenter.Subscribe<BindableObject, string>(
                this, MessageTypes.PageCompleted.ToString(), OnPageCompleted);
        }

        private void InitRoutes()
        {
            var routesArr = new IHasRoute[]
            {
            new RouteItem("///", nameof(RaceSelectionModel)),
            new RouteItem("///", nameof(ClassSelectionModel)),
            new RouteItem("///", nameof(AbilityScoreSelectionModel)),
            new RouteItem("///", nameof(BackgroundSelectionModel)),
            };
            routes = new RouteCollection(routesArr);
        }

        private void OnPageCompleted(object sender, string currentPage)
        {
            routes.GetNextAvailableRoute(currentPage)?.TryGo();
        }

        private void InitModels()
        {
            InitModel<RaceSelectionModel>();
            InitModel<ClassSelectionModel>();
            InitModel<AbilityScoreSelectionModel>();
            InitModel<BackgroundSelectionModel>();
        }

        private void InitModel<TModel>() where TModel : BindableObject
        {
            SubscribeToSelection<TModel>();
        }

        private void SubscribeToSelection<TModel>() where TModel : BindableObject
        {
            MessagingCenter.Subscribe<TModel, Selection>(
                this, MessageTypes.SelectionMade.ToString(), OnSelectionMade);
        }

        private void OnSelectionMade(object sender, Selection selection)
        {
            stateManager.SetValue(selection.Property, selection.Value);
        }
    }
}
