using Domain;

namespace DnD_Helper.Resources.Controls;

public partial class AbilityScoreControl : ContentView
{
	private int value = 0;
	private AbilityName abilityName;

	public AbilityScoreControl()
	{
		InitializeComponent();
	}

	public string ValueDisplay
		=> value.ToString();

    public AbilityScore AbilityScore
		=> new(abilityName, value);
}