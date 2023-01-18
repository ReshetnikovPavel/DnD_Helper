using DndHelper.App.ViewModels;

namespace DnD_Helper;

public partial class SubraceSelectionPage : ContentPage
{
    public SubraceSelectionPage(SubraceSelectionModel model)
    {
        InitializeComponent();
        BindingContext = model;
    }
}