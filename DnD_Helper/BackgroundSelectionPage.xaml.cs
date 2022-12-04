namespace DnD_Helper;

public partial class BackgroundSelectionPage : ContentPage
{
	public BackgroundSelectionPage()
	{
		InitializeComponent();

        BackgroundList.BindingContext = this;
	}

    public IEnumerable<string> BackgroundNames
        => AppShell.Singleton.BackgroundRepository.GetNames();

    private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        AppShell.Singleton.SelectedBackgroundName = e.Item.ToString();
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        AppShell.Singleton.SelectedName = e.NewTextValue;
    }

    private void NextButton_Clicked(object sender, EventArgs e)
    {
        AppShell.Singleton.GoToNextPage(nameof(BackgroundSelectionPage));
    }
}