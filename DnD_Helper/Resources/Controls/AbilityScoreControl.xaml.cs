using Domain;
using System.Runtime.CompilerServices;

namespace DnD_Helper.Resources.Controls;

public partial class AbilityScoreControl : Grid
{
	public static readonly BindableProperty CounterSourceProperty = BindableProperty.Create(
		nameof(CounterSource), typeof(ImageSource), typeof(AbilityScoreControl));

	public AbilityScoreControl()
	{
		InitializeComponent();
	}

	public ImageSource CounterSource
	{
		get => (ImageSource)GetValue(CounterSourceProperty); 
		set => SetValue(CounterSourceProperty, value);
	}

    protected override void OnPropertyChanged(string propertyName)
    {
        base.OnPropertyChanged(propertyName);

		if(propertyName == CounterSourceProperty.PropertyName)
			CounterImage.Source = CounterSource;
    }
}