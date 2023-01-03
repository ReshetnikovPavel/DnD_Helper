using DnD_Helper.ApplicationClasses;
using DndHelper.Domain.Repositories;
using System.Diagnostics.Contracts;
using System.Windows.Input;
using DndHelper.Domain.Dnd;
using DndHelper.App.ViewModels;

namespace DnD_Helper;

public partial class AppShell : Shell
{
    public AppShell(AppShellViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void BackToMenu_Clicked(object sender, EventArgs e)
    {
        var choice = await DisplayAlert("Вернуться в меню?",
            "Весь прогресс будет утерян", "Да", "Нет");
        if (choice)
            App.Current.MainPage = new MenuShell();
    }

    protected override bool OnBackButtonPressed()
            => true; // Disables the Android back button
}
