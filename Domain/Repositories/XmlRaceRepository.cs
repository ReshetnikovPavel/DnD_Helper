using System.Xml.Linq;
using Infrastructure;

namespace Domain.Repositories;

public class XmlRaceRepository : XmlRepository, IRaceRepository
{
	public XmlRaceRepository() : base("Races", "race")
	{
		
	}


	public Race GetRaceByName(string name)
	{
		var race = Compendium.Element(name) ?? throw new NullReferenceException($"{nameof(XmlRaceRepository)} has no race named {name}");
		throw new NotImplementedException();
	}
	
}