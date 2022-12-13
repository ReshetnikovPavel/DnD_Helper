using System.ComponentModel;
using Infrastructure;
using static Microsoft.Maui.ApplicationModel.Permissions;

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
		return text.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim());
	}

	public Speed ParseSpeed(string speed)
	{
		if (speed == null)
			return null;
		
		var speedValue = int.Parse(speed);
		return new Speed(speedValue);
	}

	public AbilityScoreBonus ParseAbilityScoreBonus(string abilityScoreBonus)
	{
        if (abilityScoreBonus == null)
            return null;

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

	public (int level, string spell) ParseSpell(string spell)
	{
		var elements = spell.Split(": ");
		var level = int.Parse(elements[0]);
		var name = elements[1];

        return (level, name);
    }

	public Weapon ParseWeapon(string weapon)
	{
        if (weapon == null)
            return null;
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

    public string ParseSkillNameBack(SkillName skill)
    {
        return skill switch
        {
            SkillName.Acrobatics => "Акробатика",
            SkillName.AnimalHandling => "Уход за животными",
            SkillName.Arcana => "Магия",
            SkillName.Athletics => "Атлетика",
            SkillName.Deception => "Обман",
            SkillName.History => "История",
            SkillName.Insight => "Проницательность",
            SkillName.Intimidation => "Запугивание",
            SkillName.Investigation => "Анализ",
            SkillName.Medicine => "Медицина",
            SkillName.Nature => "Природа",
            SkillName.Perception => "Внимательность",
            SkillName.Performance => "Выступление",
            SkillName.Persuasion => "Убеждение",
            SkillName.Religion => "Религия",
            SkillName.SleightOfHand => "Ловкость рук",
            SkillName.Stealth => "Скрытность",
            SkillName.Survival => "Выживание",
            _ => throw new InvalidEnumArgumentException("Invalid skill name")
        };
    }

    public string ParseAbilityNameBack(AbilityName ability)
    {
        return ability switch
        {
            AbilityName.Strength => "Сила",
            AbilityName.Dexterity => "Ловкость",
            AbilityName.Constitution => "Телосложение",
            AbilityName.Intelligence => "Интеллект",
            AbilityName.Wisdom => "Мудрость",
            AbilityName.Charisma => "Харизма",
            _ => throw new InvalidEnumArgumentException("Invalid ability name")
        };
    }

    public ChooseMany<T> ParseChooseMany<T>(string choiceOption, Func<string, T> parse)
	{
        if (choiceOption == null)
            return null;
        var split = choiceOption.Split(": ");
		var howMany = int.Parse(split[0]);
		var entries = ParseManyAnyType(split[1], parse);

        return new ChooseMany<T>(entries, howMany);
    }

    public IEnumerable<ChooseRelational<T1, T2>> ParseChooseRelational<T1, T2>(string choiceOption, IEnumerable<T1> from, Func<string, T2> parse)
    {
        var split = choiceOption.Split(": ");
        var howMany = int.Parse(split[0]);
		var entry = parse(split[1]);

        for (var i = 0; i < howMany; i++)
        {
            yield return new ChooseRelational<T1, T2>()
            {
                Options = from,
                Value = entry
            };
        }
    }

    public Armor ParseArmor(string armor)
	{
		return new Armor(armor);
	}

    public ArmorType ParseArmorType(string armorType)
    {
        return new ArmorType(armorType);
    }

    public Instrument ParseInstrument(string instrument)
	{
		return new Instrument(instrument);
	}

	public Equipment ParseEquipment(string equipment)
	{
		return new Equipment(equipment);
	}

    public Feat ParseFeat(string feat)
    {
        return new Feat(feat);
    }

    public IEnumerable<T> ParseMany<T>(string from, Func<string, T> applyParse)
    {
        return ParseManyAnyType(from, applyParse);
    }

    public IEnumerable<T> ParseManyToGetEnums<T>(string from, Func<string, T> applyParse) where T : Enum
    {
        return ParseManyAnyType(from, applyParse);
    }

    private SpellComponent ParseSpellComponent(char spellComponent)
    {
        return spellComponent switch
        {
            'В' => SpellComponent.Verbal,
            'С' => SpellComponent.Somatic,
            'М' => SpellComponent.Material,
            _ => throw new ArgumentException()
        };
    }

    public IEnumerable<SpellComponent> ParseSpellComponents(string spellComponents)
    {
        return spellComponents
            .ToCharArray()
			.Select(ParseSpellComponent);
    }

    public WeaponType ParseWeaponType(string weaponType)
    {
        return new WeaponType(weaponType);
    }

    private IEnumerable<T> ParseManyAnyType<T>(string from, Func<string, T> applyParse)
    {
        if (from == null)
            return Enumerable.Empty<T>();
        return Split(from).Select(applyParse);
    }
}