using DndHelper.App.ViewModels;

namespace DnD_Helper;

public partial class RaceSelectionPage : ContentPage
{
    public RaceSelectionPage(RaceSelectionModel raceSelectionViewModel)
    {
        InitializeComponent();

        BindingContext = raceSelectionViewModel;
    }
}