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
            AddModel<RaceSelectionModel>(new[] { nameof(Character.Race) });
            AddModel<SubraceSelectionModel>(new[] { "Subrace" }, () => { return false; });
            AddModel<ClassSelectionModel>(new[] { nameof(Character.Class) });
            AddModel<AbilityScoreSelectionModel>(new[] { nameof(Character.Abilities) });
            AddModel<BackgroundSelectionModel>(new[] { nameof(Character.Name), nameof(Character.Background) });
        }

        private void AddModel<TModel>(IEnumerable<string> attributes)
            where TModel : BindableObject
        {
            navigator.AddModel<TModel>(attributes, () => { return true; });
        }

        private void AddModel<TModel>(IEnumerable<string> attributes, Func<bool> goCondition)
            where TModel : BindableObject
        {
            navigator.AddModel<TModel>(attributes, goCondition);
        }
    }
}
