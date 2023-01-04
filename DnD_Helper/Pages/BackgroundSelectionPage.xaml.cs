using DndHelper.App.ViewModels;

namespace DnD_Helper;

public partial class BackgroundSelectionPage : ContentPage
{
    public BackgroundSelectionPage(BackgroundSelectionModel backgroundSelectionModel)
    {
        InitializeComponent();

        BindingContext = backgroundSelectionModel;
    }
}