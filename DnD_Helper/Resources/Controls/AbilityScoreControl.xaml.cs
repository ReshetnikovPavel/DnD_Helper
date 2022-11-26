using Domain;

namespace DnD_Helper.Resources.Controls;

public partial class AbilityScoreControl : Grid
{
	public static readonly BindableProperty AbilityScoreProperty = BindableProperty.Create(
		nameof(AbilityScore), typeof(AbilityScore), typeof(AbilityScoreControl));

    public static readonly BindableProperty CounterSourceProperty = BindableProperty.Create(
        nameof(CounterSource), typeof(ImageSource), typeof(AbilityScoreControl));

    public AbilityScoreControl()
	{
		InitializeComponent();
	}

    public AbilityScore AbilityScore
	{
		get => (AbilityScore)GetValue(AbilityScoreProperty);
		set => SetValue(AbilityScoreProperty, value);
	}

    public ImageSource CounterSource
    {
        get => (ImageSource)GetValue(CounterSourceProperty);
        set => SetValue(CounterSourceProperty, value);
    }

    public string ValueDisplay
		=> AbilityScore.Value.ToString();

	public string ModifierDisplay
		=> AbilityScore.Modifier.ToString();
}