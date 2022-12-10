using DnD_Helper.ApplicationClasses;
using Domain;

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
        MessagingCenter.Send<ContentPage, Selection>(this, Messages.AttributeSelected.ToString(),
            new Selection(nameof(Background), e.Item.ToString()));
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        MessagingCenter.Send<ContentPage, Selection>(this, Messages.AttributeSelected.ToString(),
            new Selection("Name", e.NewTextValue));
    }

    private void NextButton_Clicked(object sender, EventArgs e)
    {
        MessagingCenter.Send<ContentPage, string>(this, Messages.PageCompleted.ToString(), 
            nameof(BackgroundSelectionPage));
    }
}