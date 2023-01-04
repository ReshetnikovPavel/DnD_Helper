using DndHelper.Domain.Dnd;
using DndHelper.Domain.Repositories;
using DndHelper.Xml.Extensions;
using System.Xml.Linq;


namespace DndHelper.Xml.Repositories;

public class XmlRaceRepository : XmlRepository, IRaceRepository
{
    private readonly IDndFactory<XElement> factory;

    public XmlRaceRepository(IDndFactory<XElement> factory) : base("Races", "race")
    {
        this.factory = factory;
    }

    public Race GetRaceByName(string raceName, string subraceName)
    {
        var raceElement = Compendium.Elements("race").GetElementWithName(raceName);
        var subraceElement = raceElement?.Elements("subrace").GetElementWithName(subraceName);

        if (AreNamesNotValid(raceName, raceElement, subraceName, subraceElement))
            return null;

        var xElement = subraceElement ?? raceElement;
        return CreateRaceFromXElement(xElement, raceName, subraceName);
    }

    private static bool AreNamesNotValid(string raceName, XElement raceElement, string subraceName, XElement subraceElement)
    {
        return raceName == null || raceElement == null || subraceName != null && subraceElement == null || raceElement.HasElement("subrace") && subraceElement == null;
    }

    public IEnumerable<string> GetSubraceNames(string raceName)
    {
        var race = Compendium.Elements("race").GetElementWithName(raceName);

        return race.Elements("subrace")
            .Select(x => x.GetName());
    }
    private Race CreateRaceFromXElement(XElement xElement, string raceName, string subraceName)
    {
        return new Race
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
            Traits = Enumerable.Empty<Trait>(),
            Optionals = CreateRaceOptionals(xElement)
        };
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