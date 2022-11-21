namespace DnD_Helper;

public partial class MenuPage : ContentPage
{
	public MenuPage()
	{
		InitializeComponent();
	}

    private void StartButton_Clicked(object sender, EventArgs e)
    {
		App.Current.MainPage = new AppShell();
    }
}