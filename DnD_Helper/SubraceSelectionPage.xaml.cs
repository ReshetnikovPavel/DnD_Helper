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
}