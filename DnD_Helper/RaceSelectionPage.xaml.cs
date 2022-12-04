using Domain;
using Domain.Repositories;

namespace DnD_Helper;

public partial class RaceSelectionPage : ContentPage
{
	public RaceSelectionPage()
	{
		InitializeComponent();

        RaceList.BindingContext = this;
	}

	public IEnumerable<string> RaceNames
		=> AppShell.Singleton.RaceRepository.GetNames();


    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        MessagingCenter.Send(this, AppActions.SelectedRaceName.ToString(), 
            e.SelectedItem.ToString());
        MessagingCenter.Send<ContentPage, string>(this, AppActions.CompletedPage.ToString(),
            nameof(RaceSelectionPage));
    }
}