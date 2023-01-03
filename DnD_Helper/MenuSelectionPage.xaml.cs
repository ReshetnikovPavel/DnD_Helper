using DnD_Helper.ViewModels;

namespace DnD_Helper;

public partial class MenuSelectionPage : ContentPage
{
	public MenuSelectionPage()
	{
		InitializeComponent();

		BindingContext = new PartySelectionModel();
	}
}