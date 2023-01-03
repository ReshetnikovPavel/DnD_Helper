using DndHelper.App.ViewModels;

namespace DnD_Helper;

public partial class ClassSelectionPage : ContentPage
{
	public ClassSelectionPage(ClassSelectionModel classSelectionModel)
	{
		InitializeComponent();

        BindingContext = classSelectionModel;
	}
}