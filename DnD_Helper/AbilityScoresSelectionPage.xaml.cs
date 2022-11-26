using DnD_Helper.Resources.Controls;
using Domain;

namespace DnD_Helper;

public partial class AbilityScoresSelectionPage : ContentPage
{
	private Abilities abilities;

	public AbilityScoresSelectionPage()
	{
		InitializeComponent();

        BindingContext = this;
    }
}