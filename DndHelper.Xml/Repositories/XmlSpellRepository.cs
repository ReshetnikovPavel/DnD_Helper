using DndHelper.Domain.Dnd;
using DndHelper.Domain.Repositories;
using DndHelper.Xml.Extensions;
using System.Xml.Linq;

namespace DndHelper.Xml.Repositories;

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
        var level = int.Parse(xElement.GetElementContentWithName("level"));
        var school = xElement.GetElementContentWithName("school");
        var time = xElement.GetElementContentWithName("time");
        var classes = parser.Split(xElement.GetElementContentWithName("classes"));
        var components = parser.ParseSpellComponents(xElement.GetElementContentWithName("components"));
        return new Spell(name, level, components, school, time, classes);
    }
}