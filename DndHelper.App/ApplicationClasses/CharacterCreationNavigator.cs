/* Unmerged change from project 'DndHelper.App (net6.0-maccatalyst)'
Before:
using DndHelper;
After:
using DndHelper.App.ViewModels;
*/

/* Unmerged change from project 'DndHelper.App (net6.0-ios)'
Before:
using DndHelper;
After:
using DndHelper.App.ViewModels;
*/

/* Unmerged change from project 'DndHelper.App (net6.0-android)'
Before:
using DndHelper;
After:
using DndHelper.App.ViewModels;
*/

/* Unmerged change from project 'DndHelper.App (net6.0-windows10.0.19041.0)'
Before:
using DndHelper;
After:
using DndHelper.App.ViewModels;
*/

namespace DndHelper.App.ApplicationClasses
{
    public class CharacterCreationNavigator
    {
        private readonly IModelNavigator modelNavigator;
        private readonly ICreatesCharacter creator;

        public CharacterCreationNavigator(IModelNavigator modelNavigator, ICreatesCharacter creator)
        {
            this.modelNavigator = modelNavigator;
            this.creator = creator;
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

        private void OnPageCompleted(object sender, string currentRoute)
        {
            if (!modelNavigator.TryGoToNextRoute(currentRoute))
                TryGoToCharacterSheet();
        }
    }
}
