using Infrastructure;

namespace Domain.Repositories;

public interface IDndParser
{
	Size ParseSize(string size);
	IEnumerable<string> Split(string text);
	Speed ParseSpeed(string speed);
	AbilityScoreBonus ParseAbilityScoreBonus(string abilityScoreBonus);
	AbilityName ParseAbilityName(string abilityName);
	Language ParseLanguage(string language);
	(int level, string spell) ParseSpell(string spell);
	Weapon ParseWeapon(string weapon);
	SkillName ParseSkillName(string skillName);
    ChooseMany<T> ParseChooseMany<T>(string choiceOption, Func<string, T> parse);

    IEnumerable<ChooseRelational<T1, T2>> ParseChooseRelational<T1, T2>(string choiceOption, IEnumerable<T1> from,
        Func<string, T2> parse);

    Armor ParseArmor(string armor);
	Instrument ParseInstrument(string instrument);
	Feat ParseFeat(string feat);

    IEnumerable<T> ParseMany<T>(string from, Func<string, T> applyParse);

    IEnumerable<T> ParseManyToGetEnums<T>(string from, Func<string, T> applyParse)
        where T : Enum;
	
	IEnumerable<SpellComponent> ParseSpellComponents(string spellComponents);
}