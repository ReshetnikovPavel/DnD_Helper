using DndHelper.App.ApplicationClasses;
using DndHelper.App.RouteNavigation;
using DndHelper.Domain.Dnd;
using System.Windows.Input;

namespace DndHelper.App.ViewModels
{
    public class CharacterCreationShellViewModel : BindableObject
    {
        public ICommand GoToCharacterSheet { get; }
        private readonly CharacterCreationNavigator navigator;

        public CharacterCreationShellViewModel(IModelNavigator modelNavigator, ICreatesCharacter creator)
        {
            navigator = new CharacterCreationNavigator(modelNavigator, creator);
            GoToCharacterSheet = new Command(navigator.TryGoToCharacterSheet);
            AddModels();
        }

        private void AddModels()
        {
            AddModel<RaceSelectionModel>("///", new[] { CharacterAttributes.Race });
            AddModel<SubraceSelectionModel>("/", new[] { CharacterAttributes.Subrace });
            //AddModel<AbilityRaceBonusSelectionModel>("/", new[] { CharacterAttributes.RaceAbilityBonus });
            //AddModel<LanguageSelectionModel>("/", new[] {CharacterAttributes.Languages});
            AddModel<SkillsSelectionModel>("/", new[] {CharacterAttributes.Skills });
            AddModel<ClassSelectionModel>("///", new[] { CharacterAttributes.Class });
            AddModel<AbilityScoreSelectionModel>("///", new[] { CharacterAttributes.Abilities });
            AddModel<BackgroundSelectionModel>("///", new[] { 
                CharacterAttributes.Name, 
                CharacterAttributes.Background
            });
        }

        private void AddModel<TModel>(string prefix, IEnumerable<CharacterAttributes> attributes)
            where TModel : BindableObject
        {
            navigator.AddModel<TModel>(prefix, attributes);
        }
    }
}
