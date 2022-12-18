using DnD_Helper.ViewModels;

namespace DnD_Helper;

public partial class CharacterPage : ContentPage
{
	public CharacterPage()
	{
		InitializeComponent();

		BindingContext = new CharacterModel();
	}
}