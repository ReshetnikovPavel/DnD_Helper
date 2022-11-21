namespace Domain.Repositories;

public interface IDndParser
{
	Size ParseSize(string size);
	IEnumerable<string> Split(string text);
	Speed ParseSpeed(string speed);
	AbilityScoreBonus ParseAbilityScoreBonus(string abilityScoreBonus);
	AbilityName ParseAbilityName(string abilityName);
	Language ParseLanguage(string language);
	Spell ParseSpell(string spell);
	Weapon ParseWeapon(string weapon);
	SkillName ParseSkillName(string skillName);
	(int howMany, IEnumerable<string> entries) ParseChoiceFrom(string choiceOption);
	Armor ParseArmor(string armor);
	Instrument ParseInstrument(string instrument);
	Feat ParseFeat(string feat);

    IEnumerable<T> ParseMany<T>(string from, Func<string, T> applyParse)
		where T : IDndObject;

    IEnumerable<T> ParseManyToGetEnums<T>(string from, Func<string, T> applyParse)
        where T : Enum;
}