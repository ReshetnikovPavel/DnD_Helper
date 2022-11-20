using System.Reflection;
using System.Xml.Linq;

namespace Domain.Repositories;

public abstract class XmlRepository : IRepository
{
	protected readonly XDocument Document;
	protected readonly string ElementName;
	protected readonly XElement Compendium;

	protected XmlRepository(string fileName, string elementName)
	{
		Document = Load(fileName);
		Compendium = Document.Element("compendium")
		             ?? throw new NullReferenceException("Document does not contain a compendium element.");
		ElementName = elementName;
	}

	private static XDocument Load(string name)
	{
		var assembly = typeof(XmlRepository).GetTypeInfo().Assembly;
		var stream = assembly.GetManifestResourceStream($"Domain.{name}.xml");
		if (stream == null)
			throw new NullReferenceException($"Cannot find xml document {name}.xml");
		return XDocument.Load(stream);
	}


	public IEnumerable<string> GetNames()
	{
		return Compendium
			       .Elements(ElementName)
			       .Select(x => x.Element("name")!.Value)
		       ?? throw new NullReferenceException($"Cannot get names from xml file {Document.BaseUri}");
	}
}