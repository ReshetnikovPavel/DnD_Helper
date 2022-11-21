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
}
