namespace DnD_Helper;

public partial class MenuPage : ContentPage
{
	public MenuPage()
	{
		InitializeComponent();
	}

    private async void StartButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new AppShell());
    }
}