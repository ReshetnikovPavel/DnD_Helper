using System.Windows.Input;

namespace DnD_Helper;

public partial class AppShell : Shell
{
    public AppShell()
	{
		InitializeComponent();
	}

    private void BackToMenu_Clicked(object sender, EventArgs e)
    {
		App.Current.MainPage = new MenuShell();
    }

    protected override bool OnBackButtonPressed()
        => true;
}
