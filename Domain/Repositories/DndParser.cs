using System.ComponentModel;

namespace Domain.Repositories;

public class DndCompendiumParser : IDndParser
{
	public Size ParseSize(string size)
	{
		return size switch
		{
			"T" => Size.Tiny,
			"S" => Size.Small,
			"M" => Size.Medium,
			"L" => Size.Large,
			"H" => Size.Huge,
			"G" => Size.Gargantuan,
			_ => throw new InvalidEnumArgumentException("Invalid size")
		};
	}

	public IEnumerable<string> Split(string text)
	{
		return text.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
	}

	public Speed ParseSpeed(string speed)
	{
		var speedValue = int.Parse(speed);
		return new Speed(speedValue);
	}

	public AbilityScoreBonus ParseAbilityScoreBonus(string abilityScoreBonus)
	{
		var elements = abilityScoreBonus.Split(" ");
		var abilityName = ParseAbilityName(elements[0]);
		var bonus = int.Parse(elements[1]);
		
		return new AbilityScoreBonus(abilityName, bonus);
	}

	public AbilityName ParseAbilityName(string abilityName)
	{
		return abilityName switch
		{
			"Str" => AbilityName.Strength,
			"Dex" => AbilityName.Dexterity,
			"Con" => AbilityName.Constitution,
			"Int" => AbilityName.Intelligence,
			"Wis" => AbilityName.Wisdom,
			"Cha" => AbilityName.Charisma,
			_ => throw new InvalidEnumArgumentException("Invalid ability name")
		};
	}

	public Language ParseLanguage(string language)
	{
		return new Language(language);
	}

	public Spell ParseSpell(string spell)
	{
		var elements = spell.Split(": ");
		var level = int.Parse(elements[0]);
		var name = elements[1];
		
		return new Spell(name, level);
	}

	public Weapon ParseWeapon(string weapon)
	{
		return new Weapon(weapon);
	}

	public SkillName ParseSkillName(string skillName)
	{
		return skillName switch
		{
			"Acrobatics" => SkillName.Acrobatics,
			"Animal Handling" => SkillName.AnimalHandling,
			"Arcana" => SkillName.Arcana,
			"Athletics" => SkillName.Athletics,
			"Deception" => SkillName.Deception,
			"History" => SkillName.History,
			"Insight" => SkillName.Insight,
			"Intimidation" => SkillName.Intimidation,
			"Investigation" => SkillName.Investigation,
			"Medicine" => SkillName.Medicine,
			"Nature" => SkillName.Nature,
			"Perception" => SkillName.Perception,
			"Performance" => SkillName.Performance,
			"Persuasion" => SkillName.Persuasion,
			"Religion" => SkillName.Religion,
			"Sleight of Hand" => SkillName.SleightOfHand,
			"Stealth" => SkillName.Stealth,
			"Survival" => SkillName.Survival,
			_ => throw new InvalidEnumArgumentException("Invalid skill name")
		};
	}

	public (int howMany, IEnumerable<string> entries) ParseChoiceFrom(string choiceOption)
	{
		var elements = choiceOption.Split(": ");
		var howMany = int.Parse(elements[0]);
		var entries = Split(elements[1]);
		
		return (howMany, entries);
	}

	public Armor ParseArmor(string armor)
	{
		return new Armor(armor);
	}

	public Instrument ParseInstrument(string instrument)
	{
		return new Instrument(instrument);
	}
}