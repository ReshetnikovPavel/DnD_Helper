using DndHelper.Domain.Dnd;
using DndHelper.Domain.Repositories;
using DndHelper.Infrastructure;
using DndHelper.Xml.Extensions;
using System.Xml.Linq;

namespace DndHelper.Xml.Repositories;

public class DndCompendiumFactory : IDndFactory<XElement>
{
    private readonly IDndParser parser;
    private readonly ILanguageRepository languageRepository;
    private readonly ISpellRepository spellRepository;

    public DndCompendiumFactory(IDndParser parser, ILanguageRepository languageRepository,
        ISpellRepository spellRepository)
    {
        this.parser = parser;
        this.languageRepository = languageRepository;
        this.spellRepository = spellRepository;
    }

    public ChooseMany<Instrument> GetOptionalInstruments(XElement xElement)
    {
        if (!xElement.HasElement("possessionInstrumentFree"))
            return null;
        return parser.ParseChooseMany(xElement.GetElementContentWithName("possessionInstrumentFree"),
            x => new Instrument(x));
    }

    public ChooseMany<Language> GetOptionalLanguage(XElement xElement)
    {
        if (!xElement.HasElement("LanguageFree"))
            return null;
        var options = languageRepository.GetNames().Select(x => new Language(x));
        var amount = int.Parse(xElement.GetElementContentWithName("LanguageFree"));
        return new ChooseMany<Language>(options, amount);
    }

    public IEnumerable<ChooseRelational<AbilityName, int>> GetOptionalAbilityScoreBonuses(XElement xElement)
    {
        if (!xElement.HasElement("abilityFree"))
            return null;
        return parser.ParseChooseRelational(
            xElement.GetElementContentWithName("abilityFree"),
            Enum.GetValues<AbilityName>(),
            int.Parse);
    }

    public ChooseMany<SkillName> GetOptionalSkillProficiencies(XElement xElement)
    {
        if (!xElement.HasElement("proficiencyFree"))
            return null;
        return new ChooseMany<SkillName>(
            Enum.GetValues<SkillName>(),
            int.Parse(xElement.GetElementContentWithName("proficiencyFree")));
    }

    public ChooseMany<Spell> GetOptionalSpell(XElement xElement, string className)
    {
        var howMany = int.Parse(xElement.GetElementContentWithName("spellFree"));
        var spells = spellRepository.GetNamesForClass(className).Select(spellRepository.GetSpell);
        return new ChooseMany<Spell>(spells, howMany);
    }

    public ChooseMany<Spell> GetOptionalSpell(XElement xElement)
    {
        if (!xElement.HasElement("spellFree"))
            return null;
        var (className, howMany, level) = ParseOptionalSpellIfStringContainsClassName(xElement);

        var options = spellRepository
            .GetNamesForClass(className)
            .Select(x => spellRepository.GetSpell(x))
            .Where(x => x.Level == level);

        return new ChooseMany<Spell>(options, howMany);
    }

    private static (string className, int howMany, int level) ParseOptionalSpellIfStringContainsClassName(XElement xElement)
    {
        var parsed = xElement
            .GetElementContentWithName("spellFree")
            .Split(':')
            .Select(x => x.Trim())
            .ToArray();
        var className = parsed[0];
        var howMany = int.Parse(parsed[1]);
        var level = int.Parse(parsed[2]);
        return (className, howMany, level);
    }


    public Domain.Dnd.Size GetSize(XElement xElement)
    {
        return parser.ParseSize(xElement.GetElementContentWithName("size"));
    }

    public Speed GetSpeed(XElement xElement)
    {
        return parser.ParseSpeed(xElement.GetElementContentWithName("speed"));
    }

    public IEnumerable<Language> GetLanguages(XElement xElement)
    {
        return parser.ParseMany(xElement.GetElementContentWithName("language"), parser.ParseLanguage);
    }

    public IEnumerable<AbilityScoreBonus> GetAbilityScoreBonuses(XElement xElement)
    {
        return parser.ParseMany(xElement.GetElementContentWithName("ability"), parser.ParseAbilityScoreBonus);
    }

    public IEnumerable<(int level, Spell spell)> GetSpells(XElement xElement)
    {
        (int level, Spell spell) ApplyParse(string x)
        {
            var (level, spell) = parser.ParseSpell(x);
            return (level, spellRepository.GetSpell(spell));
        }

        return parser.ParseMany(xElement.GetElementContentWithName("spell"), ApplyParse);
    }

    public IEnumerable<Weapon> GetWeaponProficiencies(XElement xElement)
    {
        return parser.ParseMany(xElement.GetElementContentWithName("possessionWeapons"), parser.ParseWeapon);
    }

    public IEnumerable<SkillName> GetSkillProficiencies(XElement xElement)
    {
        return parser.ParseManyToGetEnums(xElement.GetElementContentWithName("skill"), parser.ParseSkillName);
    }

    public IEnumerable<Instrument> GetInstrumentProficiencies(XElement xElement)
    {
        return parser.ParseMany(xElement.GetElementContentWithName("instrument"), parser.ParseInstrument);
    }

    public IEnumerable<Feat> GetFeats(XElement xElement)
    {
        return parser.ParseMany(xElement.GetElementContentWithName("feat"), parser.ParseFeat);
    }
}