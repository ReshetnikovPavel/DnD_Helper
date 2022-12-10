using DnD_Helper.ViewModels;

namespace DnD_Helper;

public partial class AbilityScoresSelectionPage : ContentPage
{
	public AbilityScoresSelectionPage(AbilityScoreSelectionModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}