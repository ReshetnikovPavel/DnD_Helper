using DnD_Helper.ApplicationClasses;
using Domain.Repositories;
using System.Diagnostics.Contracts;
using System.Windows.Input;
using Domain;

namespace DnD_Helper;

public enum Messages
{
    AttributeSelected,
    PageCompleted
};

public partial class AppShell : Shell
{
    public static AppShell Singleton { get; private set; }

    public IRaceRepository RaceRepository { get; private set; }
    public IClassRepository ClassRepository { get; private set; }
    public IBackgroundRepository BackgroundRepository { get; private set; }
    public Character Character { get; private set; }
    public Abilities Abilities { get; private set; }
    public DndCompendiumParser Parser { get; private set; }  

    private RouteCollection routes;
    private RouteItem characterSheetRoute;
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

    public void GoToNextPage(string currentRoute)
        => routes.GoToNext(currentRoute);

    private void InitRoutes()
    {
        //Routing.RegisterRoute(nameof(CharacterSheetPage), typeof(CharacterSheetPage));
        //characterSheetRoute = new RouteItem("///", nameof(CharacterSheetPage));
        //characterSheetRoute.TriedToGo += OnTryGoToCharacterSheet;

        var routesArr = new IHasRoute[]
        {
            new RouteItem("///", nameof(RaceSelectionPage)),
            //new RouteItem("///", nameof(SubraceSelectionPage), CanGoToSubracePage),
            new RouteItem("///", nameof(ClassSelectionPage)),
            new RouteItem("///", nameof(AbilityScoresSelectionPage)),
            new RouteItem("///", nameof(BackgroundSelectionPage)),
            //characterSheetRoute
        };
        routes = new RouteCollection(routesArr);
    }

    private void InitDomain()
    {
        Parser = new DndCompendiumParser();
        var factory = new DndCompendiumFactory(
            Parser,
            new XmlLanguageRepository(),
            new XmlSpellRepository(Parser));
        RaceRepository = new XmlRaceRepository(factory);
        ClassRepository = new XmlClassRepository(Parser, factory);
        BackgroundRepository = new XmlBackgroundRepository(Parser, factory);
        Abilities = new Abilities(8, 8, 8, 8, 8, 8);
    }

    private void InitMessaging()
    {
        MessagingCenter.Subscribe<ContentPage, string>(
            this, Messages.PageCompleted.ToString(), OnPageCompleted);
        MessagingCenter.Subscribe<RaceSelectionPage, Selection>(
            this, Messages.AttributeSelected.ToString(), OnAttributeSelected);
        MessagingCenter.Subscribe<ClassSelectionPage, Selection>(
            this, Messages.AttributeSelected.ToString(), OnAttributeSelected);
        MessagingCenter.Subscribe<BackgroundSelectionPage, Selection>(
            this, Messages.AttributeSelected.ToString(), OnAttributeSelected);
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

    private void OnPageCompleted(object sender, string page)
    {
        GoToNextPage(page);
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
