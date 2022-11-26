using System.Xml.Linq;
using Infrastructure;

namespace Domain.Repositories;

public class XmlRaceRepository : XmlRepository, IRaceRepository
{
    private readonly IDndParser parser;
    private readonly ILanguageRepository languageRepository;
    private readonly ISpellRepository spellRepository;

    public XmlRaceRepository(IDndParser parser, ILanguageRepository languageRepository, ISpellRepository spellRepository) : base("Races", "race")
    {
        this.parser = parser;
        this.languageRepository = languageRepository;
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

    private RaceOptionals CreateRaceOptionals(XElement xElement)
    {
        var optionals = new RaceOptionals()
        {
            Languages = new ChooseMany<Language>(languageRepository.GetNames().Select(x => new Language(x)), int.Parse(xElement.GetContentWithTag("LanguageFree"))),
            AbilityScoreBonuses = parser.ParseChooseRelational(xElement.GetContentWithTag("abilityFree"), Enum.GetValues<AbilityName>(), int.Parse),
            SkillProficiencies = new ChooseMany<SkillName>(Enum.GetValues<SkillName>(), int.Parse(xElement.GetContentWithTag("proficiencyFree"))),
            
        };
        return optionals;
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

    private IEnumerable<(int level, Spell spell)> GetSpells(XElement xElement)
    {
        (int level, Spell spell) ApplyParse(string x)
        {
            var (level, spell) = parser.ParseSpell(x);
            return (level, spellRepository.GetSpell(spell));
        }

        return parser.ParseMany(xElement.GetContentWithTag("spell"), ApplyParse);
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