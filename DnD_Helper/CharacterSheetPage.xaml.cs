using Domain;

namespace DnD_Helper;

public partial class CharacterSheetPage : ContentPage
{
	public CharacterSheetPage()
	{
		InitializeComponent();

		BindingContext = this;
	}

	public string NameDisplay
		=> $"Имя: {AppShell.Singleton.SelectedName}";

    public string MainInfoDisplay
	{
		get
		{
			var ch = AppShell.Singleton.Character;
			var race = ch.Race.SubraceName == null ? ch.Race.Name : ch.Race.SubraceName;
			return $"{race}, {ch.Class.Name}, {ch.Background.Name}";
		}
	}

	public string SpeedDisplay
		=> $"Скорость: {AppShell.Singleton.Character.Speed.Value}";

	public string ArmourClassDisplay
		=> $"КД: {10 + AppShell.Singleton.Character.Abilities[AbilityName.Dexterity].Modifier}";

	public string InitiativeDisplay
		=> $"Инициатива: +{AppShell.Singleton.Character.Abilities[AbilityName.Dexterity].Modifier}";

	public string HpDisplay
	{
		get
		{
			var ch = AppShell.Singleton.Character;
			return $"Хитпоинты: {Convert.ToInt32(ch.HitDice.Total.Sides) + ch.Abilities[AbilityName.Constitution].Modifier}";
		}
    }

    public IEnumerable<string> AbilitiesDisplay
    {
        get
        {
            var abilities = AppShell.Singleton.Character.Abilities;
            return abilities
                .Select(pair => $"{pair.Key}: {pair.Value.Modifier}");
        }
    }

    public IEnumerable<string> SkillsDisplay
	{
		get
		{
			var skills = AppShell.Singleton.Character.Skills;
			return skills
				.Select(pair => $"{pair.Key}: {pair.Value.Modifier}");
		}
	}

}