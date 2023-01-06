using DndHelper.App.ViewModels;

namespace DnD_Helper;

public partial class EquipmentSelectionPage : ContentPage
{
    public EquipmentSelectionPage()
    {
        InitializeComponent();

        BindingContext = new EquipmentSelectionModel();
    }
}