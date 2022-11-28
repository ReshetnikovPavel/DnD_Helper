using System.Xml.Linq;
using Infrastructure;

namespace Domain.Repositories;

public class XmlBackgroundRepository : XmlRepository, IBackgroundRepository
{
    private readonly IDndParser parser;
    public XmlBackgroundRepository(IDndParser parser) : base("Background", "background")
    {
        this.parser = parser;
    }

    public Background GetBackground(string name)
    {
        var xElement = GetBackgroundXElement(name);
        return CreateBackground(xElement);
    }

    private XElement GetBackgroundXElement(string name)
    {
        return Compendium
            .Elements(ElementName)
            .First(x => x.GetName() == name);
    }

    private Background CreateBackground(XElement xElement)
    {
        var name = xElement.GetName();
        var skill = parser.ParseMany(xElement.GetContentWithTag("proficiency"), parser.ParseSkillName);
        var money = int.Parse(xElement.GetContentWithTag("money"));
        var equipment = parser.ParseMany(xElement.GetContentWithTag("equipment"), parser.ParseInstrument); //???
        var instrument = parser.ParseMany(xElement.GetContentWithTag("instrument"), parser.ParseInstrument);
        var posessionInstrument = parser.ParseMany(xElement.GetContentWithTag("posessionInstrument"), parser.ParseInstrument);
        var posessionInstrumentFree = parser.ParseChooseMany(xElement.GetContentWithTag("possessionInstrumentFree"), x => new Instrument(x));
        var languageFree = int.Parse(xElement.GetContentWithTag("languageFree"));
        return new Background(name, skill, money, equipment, instrument, posessionInstrument, posessionInstrumentFree, languageFree);
    }
}

