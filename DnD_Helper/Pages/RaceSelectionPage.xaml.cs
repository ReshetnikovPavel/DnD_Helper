using DndHelper.App.ApplicationClasses;
using DndHelper.App.ViewModels;

namespace DnD_Helper;

public partial class RaceSelectionPage : ContentPage
{
    public RaceSelectionPage(RaceSelectionModel model)
    {
        InitializeComponent();

        BindingContext = model;
    }
}