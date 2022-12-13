namespace DnD_Helper;

public partial class MenuPage : ContentPage
{
	private AppShell appShell;

	public MenuPage(AppShell appShell)
	{
		InitializeComponent();
		this.appShell = appShell;
	}

    private void StartButton_Clicked(object sender, EventArgs e)
    {
		App.Current.MainPage = appShell;
	}
}