using DnD_Helper.Resources.Controls;
using Domain;

namespace DnD_Helper;

public partial class AbilityScoresSelectionPage : ContentPage
{
	private Abilities abilities = new Abilities(8, 8, 8, 8, 8, 8);
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

	private void OnPointsUpdated(object sender, EventArgs e)
	{
        OnPropertyChanged(nameof(PointsLeft));
    }

    private void NextButton_Clicked(object sender, EventArgs e)
    {
		AppShell.Singleton.GoToNextPage(nameof(AbilityScoresSelectionPage));
    }
}