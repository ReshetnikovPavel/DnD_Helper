namespace DnD_Helper;

public partial class ClassSelectionPage : ContentPage
{
	public ClassSelectionPage()
	{
		InitializeComponent();

		ClassList.BindingContext = this;
	}

	public IEnumerable<string> ClassNames
		=> AppShell.Singleton.ClassRepository.GetNames();

    private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        AppShell.Singleton.SelectedClassName = e.Item.ToString();
        MessagingCenter.Send<ContentPage, string>(this, AppActions.CompletedPage.ToString(),
            nameof(ClassSelectionPage));
    }
}