namespace DnD_Helper;

public partial class SubraceSelectionPage : ContentPage
{
	public SubraceSelectionPage()
	{
		InitializeComponent();
		BindingContext = this;

		UpdateItemSource(this);
		MessagingCenter.Subscribe<RaceSelectionPage>(this, "SelectedRaceName", UpdateItemSource);
	}

	private void UpdateItemSource(object sender)
	{
		SubraceListView.ItemsSource = AppShell.Singleton.GetSubraceNames();
    }

    private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        AppShell.Singleton.SelectedSubRaceName = e.Item.ToString();
        AppShell.Singleton.GoToNextPage($"///{nameof(SubraceSelectionPage)}");
    }
}