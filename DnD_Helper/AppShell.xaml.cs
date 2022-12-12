using DnD_Helper.ApplicationClasses;
using Domain.Repositories;
using System.Diagnostics.Contracts;
using System.Windows.Input;
using Domain;
using DnD_Helper.ViewModels;

namespace DnD_Helper;

public partial class AppShell : Shell
{
    public static AppShell Singleton { get; private set; }
    public Character Character { get; private set; }
    public Abilities Abilities { get; private set; }

    private RouteCollection routes;
    //private RouteItem characterSheetRoute;
    private Dictionary<string, string> stateManager;
    

    public AppShell()
    {
        InitializeComponent();
        Singleton = this;
        MainFlyout.BindingContext = this;
        stateManager = new Dictionary<string, string>();
        InitRoutes();
        InitMessaging();
        InitDomain();

        SubracePage.IsVisible = false;
    }

    //public string SelectedSubRaceName { get; set; }
    //public string SelectedClassName { get; set; }
    //public string SelectedBackgroundName { get; set; }
    //public string SelectedName { get; set; }

    //public IEnumerable<string> GetSubraceNames()
    //    => RaceRepository.GetSubraceNames(SelectedRaceName);

    private void InitRoutes()
    {
        //Routing.RegisterRoute(nameof(CharacterSheetPage), typeof(CharacterSheetPage));
        //characterSheetRoute = new RouteItem("///", nameof(CharacterSheetPage));
        //characterSheetRoute.TriedToGo += OnTryGoToCharacterSheet;

        var routesArr = new IHasRoute[]
        {
            new RouteItem("///", nameof(RaceSelectionModel)),
            new RouteItem("///", nameof(ClassSelectionModel)),
            new RouteItem("///", nameof(AbilityScoreSelectionModel)),
            new RouteItem("///", nameof(BackgroundSelectionModel)),
        };
        routes = new RouteCollection(routesArr);
    }

    private void InitDomain()
    {
        Abilities = new Abilities(8, 8, 8, 8, 8, 8);
    }

    private void InitMessaging()
    {
        MessagingCenter.Subscribe<BindableObject, string>(
            this, MessageTypes.PageCompleted.ToString(), OnPageCompleted);
        MessagingCenter.Subscribe<RaceSelectionPage, Selection>(
            this, MessageTypes.AttributeSelected.ToString(), OnAttributeSelected);
        MessagingCenter.Subscribe<ClassSelectionModel, Selection>(
            this, MessageTypes.AttributeSelected.ToString(), OnAttributeSelected);
        MessagingCenter.Subscribe<BackgroundSelectionPage, Selection>(
            this, MessageTypes.AttributeSelected.ToString(), OnAttributeSelected);
    }

    //private bool CanGoToSubracePage()
    //    => GetSubraceNames().Any();

    //private bool CanGoToCharacterSheet()
    //{
    //    return stateManager.ContainsKey(nameof(Race))
    //    //&& (!CanGoToSubracePage() || SelectedSubRaceName != null)
    //    && SelectedClassName != null
    //    && SelectedName != null
    //    && SelectedBackgroundName != null;
    //}

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

    private void OnAttributeSelected(object sender, Selection selection)
    {
        if(!stateManager.ContainsKey(selection.Type))
            stateManager.Add(selection.Type, selection.Value);
        else
            stateManager[selection.Type] = selection.Value;
    }

    private void OnPageCompleted(object sender, string currentPage)
    {
        routes.GetNextAvailableRoute(currentPage)?.TryGo();
    }

    //private void OnRaceNameSelected(object sender, Selection selection)
    //{
    //    SubracePage.IsVisible = CanGoToSubracePage();
    //    SelectedSubRaceName = null;
    //}

    //private async void OnTryGoToCharacterSheet(object sender, EventArgs e)
    //{
    //    //if (!CanGoToCharacterSheet())
    //    //{
    //    //    await DisplayAlert("Невозможно перейти в лист персонажа", "Не все поля заполнены", "Эх");
    //    //    return;
    //    //}
    //    Character = new Character(Abilities);
    //    Character.Race = RaceRepository.GetRaceByName(stateManager[nameof(Race)], null);
    //    Character.ApplyRace();
    //    Character.Class = ClassRepository.GetClass(SelectedClassName);
    //    Character.ApplyClass();
    //    Character.Background = BackgroundRepository.GetBackground(SelectedBackgroundName);
    //    Character.ApplyBackground();
    //}


    protected override bool OnBackButtonPressed()
        => true; // Disables the Android back button 
}
