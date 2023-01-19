using DndHelper.App.ViewModels;

namespace DnD_Helper;

public partial class PartySelectionPage : ContentPage
{
    private readonly PartySelectionModel partySelectionModel;
    public PartySelectionPage(PartySelectionModel partySelectionModel)
    {
        InitializeComponent();
        this.partySelectionModel = partySelectionModel;
        BindingContext = partySelectionModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        partySelectionModel.LoadParties();
    }
}