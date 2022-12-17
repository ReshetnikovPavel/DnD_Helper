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
            GoToCharacterSheet = new Command(TryGoToCharacterSheet);
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

        private async void TryGoToCharacterSheet()
        {
            if(!creator.CanCreate())
            {
                await Shell.Current.DisplayAlert("Не возможно перейти в лист персонажа", "Не все поля заполнены",
            "Эх");
                return;
            }
            navigator.GoToCharacterSheet(creator.Create());
        }
    }
}
