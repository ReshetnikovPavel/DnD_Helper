using Domain;
using Domain.Repositories;

namespace DnD_Helper;

public partial class RaceSelectionPage : ContentPage
{
	public RaceSelectionPage()
	{
		InitializeComponent();

		BindingContext = this;
	}

	public IEnumerable<string> RaceNames
		=> AppShell.Singleton.RaceRepository.GetNames();

    private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        AppShell.Singleton.SelectedRaceName = e.Item.ToString();
        MessagingCenter.Send<RaceSelectionPage>(this, "SelectedRaceName");
		AppShell.Singleton.GoToNextPage($"///{nameof(RaceSelectionPage)}");
    }
}