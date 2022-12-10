using DnD_Helper.ApplicationClasses;
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
        MessagingCenter.Send(this, Messages.AttributeSelected.ToString(),
            new Selection(nameof(Race), e.SelectedItem.ToString()));
        MessagingCenter.Send<ContentPage, string>(this, Messages.PageCompleted.ToString(),
            nameof(RaceSelectionPage));
    }
}