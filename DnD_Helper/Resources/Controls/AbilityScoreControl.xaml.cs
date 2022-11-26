using Domain;
using System.Runtime.CompilerServices;

namespace DnD_Helper.Resources.Controls;

public partial class AbilityScoreControl : Grid
{
	public static readonly BindableProperty CounterSourceProperty = BindableProperty.Create(
		nameof(CounterSource), typeof(ImageSource), typeof(AbilityScoreControl));

	public static readonly BindableProperty AbilityProperty = BindableProperty.Create(
		nameof(Ability), typeof(AbilityScore), typeof(AbilityScoreControl));

	public AbilityScoreControl()
	{
		InitializeComponent();
	}

	public ImageSource CounterSource
	{
		get => (ImageSource)GetValue(CounterSourceProperty); 
		set => SetValue(CounterSourceProperty, value);
	}

	public AbilityScore Ability
	{
		get => (AbilityScore)GetValue(AbilityProperty);
		set => SetValue(AbilityProperty, value);
	}

    protected override void OnPropertyChanged(string propertyName)
    {
        base.OnPropertyChanged(propertyName);

		if(propertyName == nameof(CounterSource))
			CounterImage.Source = CounterSource;
		if (propertyName == nameof(Ability))
			ValueLabel.Text = Ability.Value.ToString();
    }
}