using DnD_Helper.Resources.Controls;
using Domain;

namespace DnD_Helper;

public partial class AbilityScoresSelectionPage : ContentPage
{
	private DistributorAbilityScore distributor = new DistributorAbilityScore();

	public AbilityScoresSelectionPage()
	{
		InitializeComponent();
        BindingContext = this;

		distributor.TotalPointsUpdated += OnPointsUpdated;
    }

	public string PointsLeft
		=> $"Очков осталось: {Distributor.TotalPoints}";

	public DistributorAbilityScore Distributor
		=> distributor;

	public AbilityScore Charisma
		=> AppShell.Singleton.Abilities.Charisma;

	public AbilityScore Constitution
		=> AppShell.Singleton.Abilities.Constitution;

	public AbilityScore Dexterity
		=> AppShell.Singleton.Abilities.Dexterity;

	public AbilityScore Intelligence
		=> AppShell.Singleton.Abilities.Intelligence;

	public AbilityScore Strength
		=> AppShell.Singleton.Abilities.Strength;

	public AbilityScore Wisdom
		=> AppShell.Singleton.Abilities.Wisdom;

	private void OnPointsUpdated(object sender, EventArgs e)
	{
        OnPropertyChanged(nameof(PointsLeft));
    }

    private void NextButton_Clicked(object sender, EventArgs e)
    {
		AppShell.Singleton.GoToNextPage($"///{nameof(AbilityScoresSelectionPage)}");
    }
}