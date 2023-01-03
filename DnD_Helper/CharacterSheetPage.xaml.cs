using DnD_Helper.ViewModels;

namespace DnD_Helper;

public partial class CharacterSheetPage : ContentPage
{
	public CharacterSheetPage()
	{
		InitializeComponent();

		BindingContext = new CharacterModel();
	}

	//public string NameDisplay
	//	=> $"Имя: {AppShell.Singleton.SelectedName}";

 //   public string MainInfoDisplay
	//{
	//	get
	//	{
	//		var ch = AppShell.Singleton.Character;
	//		var race = ch.Race.SubraceName == null ? ch.Race.Name : ch.Race.SubraceName;
	//		return $"{race}, {ch.Class.Name}, {ch.Background.Name}";
	//	}
	//}

	//public string SpeedDisplay
	//	=> $"Скорость: {AppShell.Singleton.Character.Speed.Value}";

	//public string ArmourClassDisplay
	//	=> $"КД: {10 + AppShell.Singleton.Character.Abilities[AbilityName.Dexterity].Modifier}";

	//public string InitiativeDisplay
	//	=> $"Инициатива: +{AppShell.Singleton.Character.Abilities[AbilityName.Dexterity].Modifier}";

	//public string HpDisplay
	//{
	//	get
	//	{
	//		var ch = AppShell.Singleton.Character;
	//		return $"Хитпоинты: {Convert.ToInt32(ch.HitDice.Total.Sides) + ch.Abilities[AbilityName.Constitution].Modifier}";
	//	}
 //   }

 //   public IEnumerable<string> AbilitiesDisplay
 //   {
 //       get
 //       {
 //           var abilities = AppShell.Singleton.Character.Abilities;
	//		var parser = AppShell.Singleton.Parser;
 //           return abilities
 //               .Select(pair => $"{parser.ParseAbilityNameBack(pair.Key)}: {pair.Value.Modifier}");
 //       }
 //   }

 //   public IEnumerable<string> SkillsDisplay
	//{
	//	get
	//	{
	//		var skills = AppShell.Singleton.Character.Skills;
 //           var parser = AppShell.Singleton.Parser;
 //           return skills
	//			.Select(pair => $"{parser.ParseSkillNameBack(pair.Key)}: {pair.Value.Modifier}");
	//	}
	//}

	//public IEnumerable<string> ProfficienciesDisplay
	//{
	//	get
	//	{
	//		var prof1 = AppShell.Singleton.Character.WeaponsProficiencies.Select(x => x.Name);
	//		var prof2 = AppShell.Singleton.Character.InstrumentProficiencies.Select(x => x.Name);
	//		var prof3 = AppShell.Singleton.Character.Languages.Select(x => x.Name);
	//		return prof1.Concat(prof2).Concat(prof3);

	//	}
	//}

}