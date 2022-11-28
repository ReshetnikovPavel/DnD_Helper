﻿using DnD_Helper.ApplicationClasses;
using Domain.Repositories;
using System.Diagnostics.Contracts;
using System.Windows.Input;

namespace DnD_Helper;

public partial class AppShell : Shell
{
    public static AppShell Singleton { get; private set; }

    public IRaceRepository RaceRepository { get; private set; }

    private bool isRaceSelected = false;
    private RouteCollection routes;

    public AppShell()
	{
		InitializeComponent();
        BindingContext = this;
        Singleton = this;

        var routesArr = new IHasRoute[]
        {
            new RouteItem(nameof(RaceSelectionPage)),
            new RouteItem(nameof(SubraceSelectionPage)),
            new RouteItem(nameof(RaceSelectionPage))
        };
        routes = new RouteCollection(routesArr);

        var parser = new DndCompendiumParser();
        var factory = new DndCompendiumFactory(
            parser,
            new XmlLanguageRepository(),
            new XmlSpellRepository(parser));
        RaceRepository = new XmlRaceRepository(factory);
	}

    public string SelectedRaceName { get; set; }
    public bool IsRaceSelected
    {
        get => isRaceSelected;
        set
        {
            isRaceSelected = value;
            OnPropertyChanged();
        }
    }

    public IEnumerable<string> GetSubraceNames()
        => RaceRepository.GetSubraceNames(SelectedRaceName);

    public void GoToNextPage(string currentRoute)
    {
        var nextRoute = routes.GetNext(currentRoute);
        nextRoute?.Go();
    }

    private async void BackToMenu_Clicked(object sender, EventArgs e)
    {
        var choice = await DisplayAlert("Вернуться в меню?",
            "Весь прогресс будет утерян", "Да", "Нет");
        if (choice)
            App.Current.MainPage = new MenuShell();
    }

    protected override bool OnBackButtonPressed()
        => true;
}
