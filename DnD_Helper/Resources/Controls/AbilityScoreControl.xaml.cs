using Domain;

namespace DnD_Helper.Resources.Controls;

public partial class AbilityScoreControl : Grid
{
	private AbilityScore abilityScore;

	public AbilityScoreControl()
	{
		InitializeComponent();
	}

    public AbilityScore AbilityScore
	{
		get => abilityScore;
		set => abilityScore = value;
	}

	public ImageSource CounterSource { get; set; }

	public string ValueDisplay
		=> AbilityScore.Value.ToString();

	public string ModifierDisplay
		=> AbilityScore.Modifier.ToString();
}