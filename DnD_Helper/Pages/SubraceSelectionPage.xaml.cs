using DnD_Helper.ApplicationClasses;
using DndHelper.App.ViewModels;

namespace DnD_Helper;

public partial class SubraceSelectionPage : ContentPage
{
	public SubraceSelectionPage()
	{
		InitializeComponent();
		BindingContext = new SubraceSelectionModel();
	}
}