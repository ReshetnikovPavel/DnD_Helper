using System.Xml.Linq;
using Infrastructure;

namespace Domain.Repositories;

public interface IDndFactory<TFrom>
{
    ChooseMany<Instrument> GetOptionalInstruments(TFrom from);
    ChooseMany<Language> GetOptionalLanguage(TFrom from);
    IEnumerable<ChooseRelational<AbilityName, int>> GetOptionalAbilityScoreBonuses(TFrom from);
    ChooseMany<SkillName> GetOptionalSkillProficiencies(TFrom from);
    ChooseMany<Spell> GetOptionalSpell(TFrom from);
    Size GetSize(TFrom from);
    Speed GetSpeed(TFrom from);
    IEnumerable<Language> GetLanguages(TFrom from);
    IEnumerable<AbilityScoreBonus> GetAbilityScoreBonuses(TFrom from);
    IEnumerable<(int level, Spell spell)> GetSpells(TFrom from);
    IEnumerable<Weapon> GetWeaponProficiencies(TFrom from);
    IEnumerable<SkillName> GetSkillProficiencies(TFrom from);
    IEnumerable<Instrument> GetInstrumentProficiencies(TFrom from);
    IEnumerable<Feat> GetFeats(TFrom from);
}
