using Domain;

namespace DnD_Helper.Resources.Controls;

public partial class AbilityScoreControl : Grid
{
	public static readonly BindableProperty ValueDisplayProperty = BindableProperty.Create(
		nameof(ValueDisplay), typeof(string), typeof(AbilityScoreControl),
		defaultValue: "default");

	public AbilityScoreControl()
	{
		InitializeComponent();

		BindingContext = this;
	}

	public string ValueDisplay
	{
		get => GetValue(ValueDisplayProperty).ToString();
		set => SetValue(ValueDisplayProperty, value);
	}
}