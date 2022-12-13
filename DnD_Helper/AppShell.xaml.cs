using DnD_Helper.ApplicationClasses;
using Domain.Repositories;
using System.Diagnostics.Contracts;
using System.Windows.Input;
using Domain;
using DnD_Helper.ViewModels;

namespace DnD_Helper;

public partial class AppShell : Shell
{
    private RouteCollection routes;
    private Dictionary<string, object> stateManager;

    public AppShell()
    {
        InitializeComponent();
        MainFlyout.BindingContext = this;
        stateManager = new Dictionary<string, object>();
        InitRoutes();
        InitMessaging();
        SubracePage.IsVisible = false;
    }

    private void InitRoutes()
    {
        var routesArr = new IHasRoute[]
        {
            new RouteItem("///", nameof(RaceSelectionModel)),
            new RouteItem("///", nameof(ClassSelectionModel)),
            new RouteItem("///", nameof(AbilityScoreSelectionModel)),
            new RouteItem("///", nameof(BackgroundSelectionModel)),
        };
        routes = new RouteCollection(routesArr);
    }

    private void InitMessaging()
    {
        MessagingCenter.Subscribe<BindableObject, string>(
            this, MessageTypes.PageCompleted.ToString(), OnPageCompleted);
        MessagingCenter.Subscribe<RaceSelectionPage, Selection>(
            this, MessageTypes.SelectionMade.ToString(), OnSelectionMade);
        MessagingCenter.Subscribe<ClassSelectionModel, Selection>(
            this, MessageTypes.SelectionMade.ToString(), OnSelectionMade);
        MessagingCenter.Subscribe<BackgroundSelectionPage, Selection>(
            this, MessageTypes.SelectionMade.ToString(), OnSelectionMade);
    }

    private async void BackToMenu_Clicked(object sender, EventArgs e)
    {
        var choice = await DisplayAlert("Вернуться в меню?",
            "Весь прогресс будет утерян", "Да", "Нет");
        if (choice)
            App.Current.MainPage = new MenuShell();
    }

    //private void CharacterSheet_Clicked(object sender, EventArgs e)
    //{
    //    characterSheetRoute.TryGo();
    //    Shell.Current.FlyoutIsPresented = false;
    //}

    private void OnSelectionMade(object sender, Selection selection)
    {
        if(!stateManager.ContainsKey(selection.Property))
            stateManager.Add(selection.Property, selection.Value);
        else
            stateManager[selection.Property] = selection.Value;
    }

    private void OnPageCompleted(object sender, string currentPage)
    {
        routes.GetNextAvailableRoute(currentPage)?.TryGo();
    }

    protected override bool OnBackButtonPressed()
        => true; // Disables the Android back button 
}
