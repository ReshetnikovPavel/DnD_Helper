using DnD_Helper.ViewModels;

namespace DnD_Helper;

public partial class AbilityScoresSelectionPage : ContentPage
{
	public AbilityScoresSelectionPage()
	{
		InitializeComponent();
		BindingContext = new AbilityScoreSelectionModel();
    }
}