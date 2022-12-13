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
        private ICreatesCharacter creator;
        private IModelNavigator navigator;

        public AppShellViewModel()
        {
            creator = new CharacterCreator();
            navigator = new CharacterCreationNavigator();
            MessagingCenter.Subscribe<BindableObject, string>(
                this, MessageTypes.PageCompleted.ToString(), OnPageCompleted);
            AddModels();
        }

        private void AddModels()
        {
            AddModel<RaceSelectionModel>();
            AddModel<ClassSelectionModel>();
            AddModel<AbilityScoreSelectionModel>();
            AddModel<BackgroundSelectionModel>();
        }

        private void AddModel<TModel>() where TModel : BindableObject
        {
            creator.SubscribeToModel<TModel>();
            navigator.AddModel<TModel>();
        }

        private void OnPageCompleted(object sender, string currentRoute)
        {
            navigator.GoToNextRoute(currentRoute);
        }
    }
}
