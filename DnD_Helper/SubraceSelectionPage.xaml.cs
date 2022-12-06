namespace DnD_Helper;

public partial class SubraceSelectionPage : ContentPage
{
	public SubraceSelectionPage()
	{
		InitializeComponent();
		BindingContext = this;

		UpdateItemSource(this, "");
		MessagingCenter.Subscribe<RaceSelectionPage, string>(this, Messages.AttributeSelected.ToString(), 
			UpdateItemSource);
	}

	private void UpdateItemSource(object sender, string raceName)
	{
		//SubraceListView.ItemsSource = AppShell.Singleton.GetSubraceNames();
    }

	private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
	{
		//AppShell.Singleton.SelectedSubRaceName = e.Item.ToString();
  //      MessagingCenter.Send<ContentPage, string>(this, Messages.PageCompleted.ToString(),
  //          nameof(SubraceSelectionPage));
    }
}