using DnD_Helper.ApplicationClasses;
using Domain.Repositories;
using System.Diagnostics.Contracts;
using System.Windows.Input;

namespace DnD_Helper;

public partial class AppShell : Shell
{
    public static AppShell Singleton { get; private set; }

    public IRaceRepository RaceRepository { get; private set; }
    public IClassRepository ClassRepository { get; private set; }
    public IBackgroundRepository BackgroundRepository { get; private set; }

    private RouteCollection routes;
    private RouteItem characterSheetRoute;

    public AppShell()
	{
		InitializeComponent();
        BindingContext = this;
        Singleton = this;
        InitRoutes();
        InitMessaging();
        InitDomain();

        SubracePage.IsVisible = false;
	}

    public string SelectedRaceName { get; set; }
    public string SelectedSubRaceName { get; set; }
    public string SelectedClassName { get; set; }
    public string SelectedBackgroundName { get; set; }
    public string SelectedName { get; set; }

    public IEnumerable<string> GetSubraceNames()
        => RaceRepository.GetSubraceNames(SelectedRaceName);

    public void GoToNextPage(string currentRoute)
    {
        var nextRoute = routes.GetNext(currentRoute);
        nextRoute?.TryGo();
    }

    private void InitRoutes()
    {
        Routing.RegisterRoute(nameof(CharacterSheetPage), typeof(CharacterSheetPage));
        characterSheetRoute = new RouteItem($"/{nameof(CharacterSheetPage)}");

        var routesArr = new IHasRoute[]
        {
            new RouteItem($"///{nameof(RaceSelectionPage)}"),
            new RouteItem($"///{nameof(SubraceSelectionPage)}", ShouldSubraceBeVisible),
            new RouteItem($"///{nameof(ClassSelectionPage)}"),
            new RouteItem($"///{nameof(AbilityScoresSelectionPage)}"),
            new RouteItem($"///{nameof(BackgroundSelectionPage)}"),
            characterSheetRoute
        };
        routes = new RouteCollection(routesArr);
    }

    private void InitDomain()
    {
        var parser = new DndCompendiumParser();
        var factory = new DndCompendiumFactory(
            parser,
            new XmlLanguageRepository(),
            new XmlSpellRepository(parser));
        RaceRepository = new XmlRaceRepository(factory);
        ClassRepository = new XmlClassRepository(parser, factory);
        BackgroundRepository = new XmlBackgroundRepository(parser, factory);
    }

    private void InitMessaging()
    {
        MessagingCenter.Subscribe<RaceSelectionPage>(this, "SelectedRaceName", (sender)
            => SubracePage.IsVisible = ShouldSubraceBeVisible());
    }

    private bool ShouldSubraceBeVisible()
        => GetSubraceNames().Any();

    private async void BackToMenu_Clicked(object sender, EventArgs e)
    {
        var choice = await DisplayAlert("Вернуться в меню?",
            "Весь прогресс будет утерян", "Да", "Нет");
        if (choice)
            App.Current.MainPage = new MenuShell();
    }

    private void CharacterSheet_Clicked(object sender, EventArgs e)
    {
        characterSheetRoute.TryGo();
    }

    protected override bool OnBackButtonPressed()
        => true;
}
