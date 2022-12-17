using DnD_Helper.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DnD_Helper.ViewModels
{
    public class AppShellViewModel : BindableObject
    {
        public ICommand GoToCharacterSheet { get; }
        private ICreatesCharacter creator;
        private CharacterCreationNavigator navigator;

        public AppShellViewModel(ICreatesCharacter creator, CharacterCreationNavigator navigator)
        {
            this.creator = creator;
            this.navigator = navigator;
            GoToCharacterSheet = new Command(navigator.TryGoToCharacterSheet);
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
