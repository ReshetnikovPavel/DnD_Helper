/* Unmerged change from project 'DnD_Helper (net6.0-android)'
Before:
using DndHelper.Domain.Repositories;
using System.Diagnostics.Contracts;
using System.Windows.Input;
using DndHelper.Domain.Dnd;
using DndHelper.App.ViewModels;
After:
using DndHelper.App.ViewModels;
using DndHelper.Domain.Dnd;
using DndHelper.Domain.Repositories;
using System.Diagnostics.Contracts;
using System.Windows.ViewModels;
*/

/* Unmerged change from project 'DnD_Helper (net6.0-maccatalyst)'
Before:
using DndHelper.Domain.Repositories;
using System.Diagnostics.Contracts;
using System.Windows.Input;
using DndHelper.Domain.Dnd;
using DndHelper.App.ViewModels;
After:
using DndHelper.App.ViewModels;
using DndHelper.Domain.Dnd;
using DndHelper.Domain.Repositories;
using System.Diagnostics.Contracts;
using System.Windows.ViewModels;
*/

/* Unmerged change from project 'DnD_Helper (net6.0-windows10.0.19041.0)'
Before:
using DndHelper.Domain.Repositories;
using System.Diagnostics.Contracts;
using System.Windows.Input;
using DndHelper.Domain.Dnd;
using DndHelper.App.ViewModels;
After:
using DndHelper.App.ViewModels;
using DndHelper.Domain.Dnd;
using DndHelper.Domain.Repositories;
using System.Diagnostics.Contracts;
using System.Windows.ViewModels;
*/

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
