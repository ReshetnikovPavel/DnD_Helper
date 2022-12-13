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
        private Dictionary<string, object> stateManager;

        public AppShellViewModel()
        {
            stateManager = new Dictionary<string, object>();
            InitRoutes();
            InitMessaging();
        }

        private void OnSelectionMade(object sender, Selection selection)
        {
            if (!stateManager.ContainsKey(selection.Property))
                stateManager.Add(selection.Property, selection.Value);
            else
                stateManager[selection.Property] = selection.Value;
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

        private void InitMessaging()
        {
            MessagingCenter.Subscribe<BindableObject, string>(
                this, MessageTypes.PageCompleted.ToString(), OnPageCompleted);
            MessagingCenter.Subscribe<RaceSelectionPage, Selection>(
                this, MessageTypes.SelectionMade.ToString(), OnSelectionMade);
            MessagingCenter.Subscribe<ClassSelectionModel, Selection>(
                this, MessageTypes.SelectionMade.ToString(), OnSelectionMade);
            MessagingCenter.Subscribe<BackgroundSelectionPage, Selection>(
                this, MessageTypes.SelectionMade.ToString(), OnSelectionMade);
        }

        private void OnPageCompleted(object sender, string currentPage)
        {
            routes.GetNextAvailableRoute(currentPage)?.TryGo();
        }
    }
}
