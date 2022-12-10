using DnD_Helper.ApplicationClasses;
using DnD_Helper.ViewModels;
using Domain;

namespace DnD_Helper;

public partial class BackgroundSelectionPage : ContentPage
{
	public BackgroundSelectionPage(BackgroundSelectionModel backgroundSelectionModel)
	{
		InitializeComponent();

        BindingContext = backgroundSelectionModel;
	}
}