using DnD_Helper.ApplicationClasses;
using DnD_Helper.ViewModels;
using Domain;
using Domain.Repositories;

namespace DnD_Helper;

public partial class RaceSelectionPage : ContentPage
{
	public RaceSelectionPage(RaceSelectionModel raceSelectionViewModel)
	{
		InitializeComponent();

        BindingContext = raceSelectionViewModel;
	}

	public IEnumerable<string> RaceNames
		=> AppShell.Singleton.RaceRepository.GetNames();

    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        MessagingCenter.Send(this, Messages.AttributeSelected.ToString(),
            new Selection(nameof(Race), e.SelectedItem.ToString()));
        MessagingCenter.Send<ContentPage, string>(this, Messages.PageCompleted.ToString(),
            nameof(RaceSelectionPage));
    }
}