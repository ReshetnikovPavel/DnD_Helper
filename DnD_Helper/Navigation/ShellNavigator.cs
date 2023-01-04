using DndHelper.App.RouteNavigation;

namespace DnD_Helper.Navigation;

public class ShellNavigator : IShellNavigator
{
    private readonly CharacterCreationShell characterCreationShell;

    public void GoToMenu()
    {
        Application.Current!.MainPage = new MenuShell();
    }

    public void GoToCharacterCreation()
    {
        Application.Current!.MainPage = characterCreationShell;
    }

    public ShellNavigator(CharacterCreationShell characterCreationShell)
    {
        this.characterCreationShell = characterCreationShell;
    }
}