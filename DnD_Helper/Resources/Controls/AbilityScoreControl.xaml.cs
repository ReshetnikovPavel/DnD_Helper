using DndHelper.Domain.Dnd;
using DndHelper.Domain.Services;

namespace DnD_Helper.Resources.Controls;

public partial class AbilityScoreControl : Grid
{
    public static readonly BindableProperty CounterSourceProperty = BindableProperty.Create(
        nameof(CounterSource), typeof(ImageSource), typeof(AbilityScoreControl));

    public static readonly BindableProperty AbilityProperty = BindableProperty.Create(
        nameof(Ability), typeof(AbilityScore), typeof(AbilityScoreControl));

    public static readonly BindableProperty DistributorProperty = BindableProperty.Create(
        nameof(Distributor), typeof(IAbilityScoreDistributor), typeof(AbilityScoreControl));

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

    public IAbilityScoreDistributor Distributor
    {
        get => (IAbilityScoreDistributor)GetValue(DistributorProperty);
        set => SetValue(DistributorProperty, value);
    }

    protected override void OnPropertyChanged(string propertyName)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == nameof(CounterSource))
            CounterImage.Source = CounterSource;
        if (propertyName == nameof(Ability))
            ValueLabel.Text = Ability.Value.ToString();
        if (propertyName == nameof(Distributor))
        {
            Distributor.TotalPointsUpdated += OnPointsUpdated;
            OnPointsUpdated(this, EventArgs.Empty);
        }
    }

    private void PlusButton_Clicked(object sender, EventArgs e)
    {
        Distributor.BuyAbilityScoreValue(Ability);
        OnPropertyChanged(nameof(Ability));
        OnPointsUpdated(this, EventArgs.Empty);
    }

    private void MinusButton_Clicked(object sender, EventArgs e)
    {
        Distributor.SellAbilityScoreValue(Ability);
        OnPropertyChanged(nameof(Ability));
        OnPointsUpdated(this, EventArgs.Empty);
    }

    private void OnPointsUpdated(object sender, EventArgs e)
    {
        PlusButton.IsVisible = Distributor.CanBuy(Ability);
        MinusButton.IsVisible = Distributor.CanSell(Ability);
    }
}