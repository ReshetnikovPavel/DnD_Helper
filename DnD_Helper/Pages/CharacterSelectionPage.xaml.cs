using DndHelper.App.ViewModels;

namespace DnD_Helper;

public partial class CharacterSelectionPage : ContentPage
{
    private readonly CharacterSelectionModel characterSelectionModel;
    public CharacterSelectionPage(CharacterSelectionModel characterSelectionModel)
    {
        InitializeComponent();
        this.characterSelectionModel = characterSelectionModel;
        BindingContext = characterSelectionModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        characterSelectionModel.LoadCharacterNames();
    }
}