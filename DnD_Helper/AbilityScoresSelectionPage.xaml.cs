using Domain;

namespace DnD_Helper;

public partial class AbilityScoresSelectionPage : ContentPage
{
	private Abilities abilities = new Abilities(0, 0, 0, 0, 0, 0);

	public AbilityScoresSelectionPage()
	{
		InitializeComponent();
	}

    public AbilityScore Strength
        => abilities.Strength;

    public AbilityScore Intelligence
		=> abilities.Intelligence;

}