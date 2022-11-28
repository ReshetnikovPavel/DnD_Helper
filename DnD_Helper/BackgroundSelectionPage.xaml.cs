namespace DnD_Helper;

public partial class BackgroundSelectionPage : ContentPage
{
	public BackgroundSelectionPage()
	{
		InitializeComponent();

        BindingContext = this;
	}

    public IEnumerable<string> BackgroundNames
        => AppShell.Singleton.BackgroundRepository.GetNames();

    private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        AppShell.Singleton.SelectedBackgroundName = e.Item.ToString();
        AppShell.Singleton.GoToNextPage(nameof(BackgroundSelectionPage));
    }
}