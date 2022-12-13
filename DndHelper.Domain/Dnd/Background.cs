using DndHelper.Infrastructure;

namespace DndHelper.Domain.Dnd;

public class Background : ValueType<Background>, IDndObject
{
    public string Name;
    public IEnumerable<SkillName> SkillProficiencies;
    public int Money;
    public IEnumerable<Equipment> Equipment;
    public IEnumerable<Instrument> Instrument;
    public IEnumerable<Instrument> InstrumentProficiencies;
    public ChooseMany<Instrument> OptionalInstrumentProficiencies;
    public ChooseMany<Language> OptionalLanguages;

    public Background(string name, IEnumerable<SkillName> skill, int money,
                        IEnumerable<Equipment> equipment, IEnumerable<Instrument> instrument,
                        IEnumerable<Instrument> posessionInstrument, ChooseMany<Instrument> posessionInstrumentFree,
                        ChooseMany<Language> languageFree)
    {
        this.Name = name;
        this.SkillProficiencies = skill;
        this.Money = money;
        this.Equipment = equipment;
        this.Instrument = instrument;
        this.InstrumentProficiencies = posessionInstrument;
        this.OptionalInstrumentProficiencies = posessionInstrumentFree;
        this.OptionalLanguages = languageFree;
    }
}