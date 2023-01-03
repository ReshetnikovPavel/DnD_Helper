using DndHelper.App.ViewModels;

namespace DnD_Helper;

public partial class CharacterSelectionPage : ContentPage
{
    public CharacterSelectionPage(CharacterSelectionModel characterSelectionModel)
    {
        InitializeComponent();

        BindingContext = characterSelectionModel;
    }
}