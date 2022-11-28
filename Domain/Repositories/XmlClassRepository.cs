using System.Xml.Linq;
using Infrastructure;

namespace Domain.Repositories;

public class XmlClassRepository : XmlRepository, IClassRepository
{
    private IDndParser parser;
    public XmlClassRepository(IDndParser parser) : base("Classes", "class")
    {
        this.parser = parser;
    }

    public Class GetClass(string name)
    {
        var xElement = Compendium.Elements("class").GetElementWithName(name);
        var dndClass = new Class
        {
            Name = name,
            HitDice = GetHitDice(xElement),
            AbilityNamesForSavingThrows = GetAbilityNamesForSavingThrows(xElement),
            SpellAbility = GetSpellAbilityName(xElement),
            SpellSlotsTable = GetSpellSlotsTable(xElement)
        };
        return dndClass;
    }

    private HitDice GetHitDice(XElement xElement)
    {
        var hitDieNumber = int.Parse(xElement.GetContentWithTag("hd"));
        var hitDie = new HitDice(new Dice(1, (DiceName) hitDieNumber));
        return hitDie;
    }

    private IEnumerable<AbilityName> GetAbilityNamesForSavingThrows(XElement xElement)
    {
        var abilityNames = xElement.GetContentWithTag("savingThrow");
        return parser.ParseMany(abilityNames, parser.ParseAbilityName);
    }

    private AbilityName? GetSpellAbilityName(XElement xElement)
    {
        var tag = "spellAbility";
        if (!xElement.HasElement(tag))
            return null;
        return parser.ParseAbilityName(xElement.GetContentWithTag(tag));
    }

    private SpellSlotsTable GetSpellSlotsTable(XElement xElement)
    {
        var spellSlotsXElements = xElement.Elements("autolevel").Where(x => x.HasElement("slots"));
        if (!spellSlotsXElements.Any())
            return null;

        var spellSlotsTable = new SpellSlotsTable();
        foreach (var spellSlotsXElement in spellSlotsXElements)
            FillSpellSlotsTableRow(spellSlotsTable, spellSlotsXElement);

        return spellSlotsTable;
    }

    private void FillSpellSlotsTableRow(SpellSlotsTable spellSlotsTable, XElement spellSlotsXElement)
    {
        var levelXAttribute = spellSlotsXElement.Attribute("level") ?? throw new NullReferenceException("autolevel tag has no level");
        var classLevel = int.Parse(levelXAttribute.Value);
        var spellSlots = parser.ParseMany(spellSlotsXElement.GetContentWithTag("slots"), int.Parse).ToArray();
        spellSlotsTable.FillClassLevelRow(classLevel, spellSlots);
    }
}