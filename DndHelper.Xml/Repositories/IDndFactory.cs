using DndHelper.Domain.Dnd;
using DndHelper.Infrastructure;
/* Unmerged change from project 'DndHelper.Xml (net6.0-maccatalyst)'
Before:
using DndHelper.Domain.Dnd;
After:
using System.Xml.Linq;
*/

/* Unmerged change from project 'DndHelper.Xml (net6.0-ios)'
Before:
using DndHelper.Domain.Dnd;
After:
using System.Xml.Linq;
*/

/* Unmerged change from project 'DndHelper.Xml (net6.0-android)'
Before:
using DndHelper.Domain.Dnd;
After:
using System.Xml.Linq;
*/

/* Unmerged change from project 'DndHelper.Xml (net6.0-windows10.0.19041.0)'
Before:
using DndHelper.Domain.Dnd;
After:
using System.Xml.Linq;
*/


namespace DndHelper.Xml.Repositories;

public interface IDndFactory<TFrom>
{
    ChooseMany<Instrument> GetOptionalInstruments(TFrom from);
    ChooseMany<Language> GetOptionalLanguage(TFrom from);
    IEnumerable<ChooseRelational<AbilityName, int>> GetOptionalAbilityScoreBonuses(TFrom from);
    ChooseMany<SkillName> GetOptionalSkillProficiencies(TFrom from);
    ChooseMany<Spell> GetOptionalSpell(TFrom from);
    Domain.Dnd.Size GetSize(TFrom from);
    Speed GetSpeed(TFrom from);
    IEnumerable<Language> GetLanguages(TFrom from);
    IEnumerable<AbilityScoreBonus> GetAbilityScoreBonuses(TFrom from);
    IEnumerable<(int level, Spell spell)> GetSpells(TFrom from);
    IEnumerable<Weapon> GetWeaponProficiencies(TFrom from);
    IEnumerable<SkillName> GetSkillProficiencies(TFrom from);
    IEnumerable<Instrument> GetInstrumentProficiencies(TFrom from);
    IEnumerable<Feat> GetFeats(TFrom from);
}
