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
			"Акробатика" => SkillName.Acrobatics,
			"Уход за животными" => SkillName.AnimalHandling,
			"Магия" => SkillName.Arcana,
			"Атлетика" => SkillName.Athletics,
			"Обман" => SkillName.Deception,
			"История" => SkillName.History,
			"Проницательность" => SkillName.Insight,
			"Запугивание" => SkillName.Intimidation,
			"Анализ" => SkillName.Investigation,
			"Медицина" => SkillName.Medicine,
			"Природа" => SkillName.Nature,
			"Внимательность" => SkillName.Perception,
			"Выступление" => SkillName.Performance,
			"Убеждение" => SkillName.Persuasion,
			"Религия" => SkillName.Religion,
			"Ловкость рук" => SkillName.SleightOfHand,
			"Скрытность" => SkillName.Stealth,
			"Выживание" => SkillName.Survival,
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

    public Feat ParseFeat(string feat)
    {
        return new Feat(feat);
    }

    public IEnumerable<T> ParseMany<T>(string from, Func<string, T> applyParse) where T : IDndObject
    {
        return ParseManyAnyType(from, applyParse);
    }

    public IEnumerable<T> ParseManyToGetEnums<T>(string from, Func<string, T> applyParse) where T : Enum
    {
        return ParseManyAnyType(from, applyParse);
    }

    private IEnumerable<T> ParseManyAnyType<T>(string from, Func<string, T> applyParse)
    {
        if (from == null)
            return Enumerable.Empty<T>();
        return Split(from).Select(applyParse);
    }
}