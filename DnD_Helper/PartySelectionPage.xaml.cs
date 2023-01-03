using DnD_Helper.ViewModels;

namespace DnD_Helper;

public partial class PartySelectionPage : ContentPage
{
	public PartySelectionPage()
	{
		InitializeComponent();

		BindingContext = new PartySelectionModel();
	}
}