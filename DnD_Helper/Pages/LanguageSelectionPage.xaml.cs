using DndHelper.App.ViewModels;

namespace DnD_Helper;

public partial class LanguageSelectionPage : ContentPage
{
    public LanguageSelectionPage()
    {
        InitializeComponent();

        BindingContext = new LanguageSelectionModel();
    }
}