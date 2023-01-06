using DndHelper.App.ViewModels;

namespace DnD_Helper;

public partial class SpellSelectionPage : ContentPage
{
    public SpellSelectionPage()
    {
        InitializeComponent();

        BindingContext = new SpellSelectionModel();
    }
}