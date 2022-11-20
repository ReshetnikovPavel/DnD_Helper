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
}