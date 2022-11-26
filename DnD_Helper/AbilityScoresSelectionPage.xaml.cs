using DnD_Helper.Resources.Controls;
using Domain;

namespace DnD_Helper;

public partial class AbilityScoresSelectionPage : ContentPage
{
	private Abilities abilities = new Abilities(8, 8, 8, 8, 8, 8);

	public AbilityScoresSelectionPage()
	{
		InitializeComponent();

        BindingContext = this;
    }

	public AbilityScore Charisma
		=> abilities.Charisma;

	public AbilityScore Constitution
		=> abilities.Constitution;

	public AbilityScore Dexterity
		=> abilities.Dexterity;

	public AbilityScore Intelligence
		=> abilities.Intelligence;

	public AbilityScore Strength
		=> abilities.Strength;

	public AbilityScore Wisdom
		=> abilities.Wisdom;
}