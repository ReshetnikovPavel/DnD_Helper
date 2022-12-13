using DnD_Helper.ViewModels;

namespace DnD_Helper;

public partial class ClassSelectionPage : ContentPage
{
	public ClassSelectionPage(ClassSelectionModel classSelectionModel)
	{
		InitializeComponent();

        BindingContext = classSelectionModel;
	}
}