using DndHelper.App.ViewModels;
using DndHelper;

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
            var character = creator.Create();
            await Shell.Current.GoToAsync($"/{nameof(CharacterSheetViewModel)}?",
                new Dictionary<string ,object>
                {
                    ["Character"] = character
                }
                );
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
