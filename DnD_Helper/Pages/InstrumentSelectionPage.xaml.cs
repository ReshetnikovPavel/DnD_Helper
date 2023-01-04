using DndHelper.App.ViewModels;

namespace DnD_Helper;

public partial class InstrumentSelectionPage : ContentPage
{
    public InstrumentSelectionPage()
    {
        InitializeComponent();

        BindingContext = new InstrumentSelectionModel();
    }
}