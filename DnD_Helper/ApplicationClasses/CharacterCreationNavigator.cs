using DnD_Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Helper.ApplicationClasses
{
    public class CharacterCreationNavigator
    {
        private readonly IModelNavigator modelNavigator;
        private readonly ICreatesCharacter creator;

        public CharacterCreationNavigator(IModelNavigator modelNavigator, ICreatesCharacter creator) 
        {
            this.modelNavigator = modelNavigator;
            this.creator = creator;
            InitRouting();
            SubscribeToMessaging();
        }

        public CharacterCreationNavigator(ICreatesCharacter creator)
        {
            this.creator = creator;
        }

        public void AddModel<TModel>() where TModel : BindableObject
        {
            modelNavigator.AddModel<TModel>();
        }

        public async void TryGoToCharacterSheet()
        {
            if (!creator.CanCreate())
            {
                await Shell.Current.DisplayAlert("Невозможно перейти в лист персонажа",
                    "Не все поля заполнены", "Эх");
                return;
            }
            await Shell.Current.GoToAsync($"/{nameof(CharacterSheetViewModel)}");
        }

        private void SubscribeToMessaging()
        {
            MessagingCenter.Subscribe<BindableObject, string>(
                this, MessageTypes.PageCompleted.ToString(), OnPageCompleted);
        }

        private void InitRouting()
        {
            Routing.RegisterRoute(nameof(CharacterSheetViewModel), typeof(CharacterSheetPage));
        }

        private void OnPageCompleted(object sender, string currentRoute)
        {
            if (!modelNavigator.TryGoToNextRoute(currentRoute))
                TryGoToCharacterSheet();
        }
    }
}
