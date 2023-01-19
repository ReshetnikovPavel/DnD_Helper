using DndHelper.App.RouteNavigation;
using DndHelper.App.ViewModels;

namespace DnD_Helper;

public partial class CharacterCreationShell : Shell
{

    public CharacterCreationShell(CharacterCreationShellViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override bool OnBackButtonPressed()
            => true; // Disables the Android back button

    private async void BackToMenu_Clicked(object sender, EventArgs e)   
    {
        //var choice = await DisplayAlert("Вернуться в меню?",
        //    "Весь прогресс будет утерян", "Да", "Нет");
        //if (choice)
        App.Current.MainPage = new MenuShell();
    }
}
