using DndHelper.App.ViewModels;

namespace DnD_Helper;

public partial class PartySelectionPage : ContentPage
{
    public PartySelectionPage()
    {
        InitializeComponent();

        BindingContext = new PartySelectionModel();
    }
}