using Domain.Repositories;
using System.Windows.Input;

namespace DnD_Helper;

public partial class AppShell : Shell
{
    public static IRaceRepository RaceRepository { get; private set; }

    public AppShell()
	{
		InitializeComponent();

        var parser = new DndCompendiumParser();

        RaceRepository = new XmlRaceRepository(
            parser,
            new XmlLanguageRepository(),
            new XmlSpellRepository(parser));
	}

    private void BackToMenu_Clicked(object sender, EventArgs e)
    {
		App.Current.MainPage = new MenuShell();
    }

    protected override bool OnBackButtonPressed()
        => true;
}
