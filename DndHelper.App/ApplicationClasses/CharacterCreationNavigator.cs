using DndHelper.App.ApplicationClasses;
using DndHelper.App.ViewModels;
using DndHelper.Domain.Dnd;

namespace DndHelper.App.RouteNavigation
{
    public class CharacterCreationNavigator
    {
        public ICreatesCharacter Creator { get; }
        private readonly IModelNavigator modelNavigator;
        

        public CharacterCreationNavigator(IModelNavigator modelNavigator, ICreatesCharacter creator)
        {
            this.modelNavigator = modelNavigator;
            Creator = creator;
            SubscribeToMessaging();
        }

        public CharacterCreationNavigator(ICreatesCharacter creator)
        {
            this.Creator = creator;
        }

        public void AddModel<TModel>(string prefix, IEnumerable<CharacterAttributes> attributes) 
            where TModel : BindableObject
        {
            modelNavigator.AddModel<TModel>(prefix,() => attributes.Any(Creator.CanSelect));
        }

        public async void TryGoToCharacterSheet()
        {
            if (Creator.TryCreate(out var character))
                await GoToCharacterSheet(character);
            else
                await DisplayCannotGoToCharacterSheetAlert();

        }

        private static async Task DisplayCannotGoToCharacterSheetAlert()
        {
            await Shell.Current.DisplayAlert("Невозможно перейти в лист персонажа",
                "Не все поля заполнены", "Эх");
        }

        private static async Task GoToCharacterSheet(Character character)
        {
            await Shell.Current.GoToAsync($"/{nameof(CharacterSheetViewModel)}",
                new Dictionary<string, object>
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
