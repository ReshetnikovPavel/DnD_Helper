using Domain.Repositories;
using System.Diagnostics.Contracts;
using System.Windows.Input;

namespace DnD_Helper;

public partial class AppShell : Shell
{
    public static IRaceRepository RaceRepository { get; private set; }

    private static bool isRaceSelected = false;

    public AppShell()
	{
		InitializeComponent();

        var parser = new DndCompendiumParser();

        RaceRepository = new XmlRaceRepository(
            parser,
            new XmlLanguageRepository(),
            new XmlSpellRepository(parser));
	}

    public static string SelectedRaceName { get; set; }
    public static bool IsRaceSelected { get; set; }

    private void BackToMenu_Clicked(object sender, EventArgs e)
    {
		App.Current.MainPage = new MenuShell();
    }

    protected override bool OnBackButtonPressed()
        => true;
}
