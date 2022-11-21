using System.Xml.Linq;
using Infrastructure;

namespace Domain.Repositories;

public class XmlRaceRepository : XmlRepository, IRaceRepository
{
    private readonly IDndParser parser;

    public XmlRaceRepository(IDndParser parser) : base("Races", "race")
	{
        this.parser = parser;
    }

	public Race GetRaceByName(string raceName, string subraceName)
	{
		var raceElement = Compendium.Elements("race").GetElementWithName(raceName);
		var subraceElement = raceElement.Elements("subrace").GetElementWithName(subraceName);

        return CreateRaceFromXElement(subraceElement, raceName, subraceName);
    }
    public IEnumerable<string> GetSubraceNames(string raceName)
    {
        var race = Compendium.Elements("race").GetElementWithName(raceName);

        return race.Elements("subrace")
            .Select(x => x.GetName());
    }
    private Race CreateRaceFromXElement(XElement xElement, string raceName, string subraceName)
    {
        var race = new Race()
        {
            Name = raceName,
            SubraceName = subraceName,
            Size = GetSize(xElement),
            Speed = GetSpeed(xElement),
            Languages = GetLanguages(xElement),
            AbilityScoreBonuses = GetAbilityScoreBonuses(xElement),
            Spells = GetSpells(xElement),
            WeaponsProficiencies = GetWeaponProficiencies(xElement),
            SkillProficiencies = GetSkillProficiencies(xElement),
            InstrumentProfieciencies = GetInstrumentProficiencies(xElement),
            Feats = GetFeats(xElement)
        };
        return race;
    }

    private Size GetSize(XElement xElement)
    {
        return parser.ParseSize(xElement.GetContentWithTag("size"));
    }

    private Speed GetSpeed(XElement xElement)
    {
        return parser.ParseSpeed(xElement.GetContentWithTag("speed"));
    }

    private IEnumerable<Language> GetLanguages(XElement xElement)
    {
        return parser.ParseMany(xElement.GetContentWithTag("language"), parser.ParseLanguage);
    }

    private IEnumerable<AbilityScoreBonus> GetAbilityScoreBonuses(XElement xElement)
    {
        return parser.ParseMany(xElement.GetContentWithTag("ability"), parser.ParseAbilityScoreBonus);
    }

    private IEnumerable<Spell> GetSpells(XElement xElement)
    {
        return parser.ParseMany(xElement.GetContentWithTag("spell"), parser.ParseSpell);
    }

    private IEnumerable<Weapon> GetWeaponProficiencies(XElement xElement)
    {
        return parser.ParseMany(xElement.GetContentWithTag("possessionWeapons"), parser.ParseWeapon);
    }

    private IEnumerable<SkillName> GetSkillProficiencies(XElement xElement)
    {
        return parser.ParseManyToGetEnums(xElement.GetContentWithTag("skill"), parser.ParseSkillName);
    }

    private IEnumerable<Instrument> GetInstrumentProficiencies(XElement xElement)
    {
        return parser.ParseMany(xElement.GetContentWithTag("instrument"), parser.ParseInstrument);
    }

    private IEnumerable<Feat> GetFeats(XElement xElement)
    {
        return parser.ParseMany(xElement.GetContentWithTag("feat"), parser.ParseFeat);
    }
}