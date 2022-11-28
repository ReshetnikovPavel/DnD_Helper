using Domain.Repositories;
using System.Diagnostics.Contracts;
using System.Windows.Input;

namespace DnD_Helper;

public partial class AppShell : Shell
{
    public static AppShell Singleton { get; private set; }

    public IRaceRepository RaceRepository { get; private set; }

    private bool isRaceSelected = false;

    public AppShell()
	{
		InitializeComponent();
        BindingContext = this;
        Singleton = this;

        var parser = new DndCompendiumParser();
        RaceRepository = new XmlRaceRepository(
            parser,
            new XmlLanguageRepository(),
            new XmlSpellRepository(parser));
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
