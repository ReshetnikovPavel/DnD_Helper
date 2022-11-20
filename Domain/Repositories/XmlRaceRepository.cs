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
		var raceElement = GetElementWithNameFrom(Compendium.Elements("race"), raceName);
		var subraceElement = GetElementWithNameFrom(raceElement.Elements("subrace"), subraceName);

        return CreateRaceFromXElement(subraceElement, raceName, subraceName);
    }

	private Race CreateRaceFromXElement(XElement xElement, string raceName, string subraceName)
	{
        return new Race()
        {
            Name = raceName,
            SubraceName = subraceName,
            Size = parser.ParseSize(xElement.Element("size").Value),
            Speed = parser.ParseSpeed(xElement.Element("speed").Value)
        };
    }

    public IEnumerable<string> GetSubraceNames(string raceName)
    {
		var race = GetElementWithNameFrom(Compendium.Elements("race"), raceName);

		return race.Elements("subrace")
			.Select(x => GetName(x));
    }

	private static XElement GetElementWithNameFrom(IEnumerable<XElement> xElements, string name)
	{
		return xElements
			.Where(x => GetName(x) == name)
            .First();
    }

	private static string GetName(XElement xElement)
	{
		return xElement.Element("name").Value;
    }
}