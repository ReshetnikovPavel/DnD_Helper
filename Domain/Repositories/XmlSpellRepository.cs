using System.Xml.Linq;
using Infrastructure;

namespace Domain.Repositories;

public class XmlSpellRepository : XmlRepository, ISpellRepository
{
    private readonly IDndParser parser;

    public XmlSpellRepository(IDndParser parser) : base("Spells", "spell")
    {
        this.parser = parser;
    }

    public IEnumerable<string> GetNamesForClass(string className)
    {
        return Compendium
            .Elements(ElementName)
            .Where(x => x.Element("classes")
                .Value
                .Contains(className))
            .Select(x => x.GetName());
    }

    public Spell GetSpell(string name)
    {
        var xElement = GetSpellXElement(name);
        return CreateSpell(xElement);
    }

    private XElement GetSpellXElement(string name)
    {
        return Compendium
            .Elements(ElementName)
            .First(x => x.GetName() == name);
    }

    private Spell CreateSpell(XElement xElement)
    {
        var name = xElement.GetName();
        var level = int.Parse(xElement.GetContentWithTag("level"));
        var school = xElement.GetContentWithTag("school");
        var time = xElement.GetContentWithTag("time");
        var classes = parser.Split(xElement.GetContentWithTag("classes"));
        var components = parser.ParseSpellComponents(xElement.GetContentWithTag("components"));
        return new Spell(name, level, components, school, time, classes);

    }
}