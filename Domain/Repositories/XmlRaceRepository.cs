using System.Xml.Linq;
using Infrastructure;

namespace Domain.Repositories;

public class XmlRaceRepository : XmlRepository, IRaceRepository
{
    private readonly IDndFactory<XElement> factory;

    public XmlRaceRepository(IDndFactory<XElement> chooseManyFactory) : base("Races", "race")
    {
        this.factory = chooseManyFactory;
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
        var race = new Race
        {
            Name = raceName,
            SubraceName = subraceName,
            Size = factory.GetSize(xElement),
            Speed = factory.GetSpeed(xElement),
            Languages = factory.GetLanguages(xElement),
            AbilityScoreBonuses = factory.GetAbilityScoreBonuses(xElement),
            Spells = factory.GetSpells(xElement),
            WeaponsProficiencies = factory.GetWeaponProficiencies(xElement),
            SkillProficiencies = factory.GetSkillProficiencies(xElement),
            InstrumentProfieciencies = factory.GetInstrumentProficiencies(xElement),
            Feats = factory.GetFeats(xElement),
            Optionals = CreateRaceOptionals(xElement)
        };
        return race;
    }

    private RaceOptionals CreateRaceOptionals(XElement xElement)
    {
        var optionals = new RaceOptionals
        {
            Languages = factory.GetOptionalLanguage(xElement),
            AbilityScoreBonuses = factory.GetOptionalAbilityScoreBonuses(xElement),
            SkillProficiencies = factory.GetOptionalSkillProficiencies(xElement),
            Spells = factory.GetOptionalSpell(xElement),
            InstrumentProficiencies = factory.GetOptionalInstruments(xElement)
        };
        return optionals;
    }
}