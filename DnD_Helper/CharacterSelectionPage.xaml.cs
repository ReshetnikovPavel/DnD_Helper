using DnD_Helper.ViewModels;

namespace DnD_Helper;

public partial class CharacterSelectionPage : ContentPage
{
	public CharacterSelectionPage()
	{
		InitializeComponent();

		BindingContext = new CharacterSelectionModel();
	}
}