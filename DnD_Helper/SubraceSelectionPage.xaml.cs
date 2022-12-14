using DnD_Helper.ApplicationClasses;
using DnD_Helper.ViewModels;

namespace DnD_Helper;

public partial class SubraceSelectionPage : ContentPage
{
	public SubraceSelectionPage()
	{
		InitializeComponent();
		BindingContext = new SubraceSelectionModel();
	}
}