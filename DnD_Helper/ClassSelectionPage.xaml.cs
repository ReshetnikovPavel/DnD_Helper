using DnD_Helper.ApplicationClasses;
using Domain;

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
        MessagingCenter.Send<ContentPage, Selection>(this, Messages.AttributeSelected.ToString(),
            new Selection(nameof(Class), e.Item.ToString()));
        MessagingCenter.Send<ContentPage, string>(this, Messages.PageCompleted.ToString(),
            nameof(ClassSelectionPage));
    }
}