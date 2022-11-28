using Infrastructure;

namespace Domain;

public class Background : ValueType<Background>, IDndObject
{
    public string name;
    public IEnumerable<SkillName> skill;
    public int money;
    public IEnumerable<Equipment> equipment;
    public IEnumerable<Instrument> instrument;
    public IEnumerable<Instrument> posessionInstrument;
    public ChooseMany<Instrument> posessionInstrumentFree;
    public ChooseMany<Language> languageFree;

    public Background(string name, IEnumerable<SkillName> skill, int money,
                        IEnumerable<Equipment> equipment, IEnumerable<Instrument> instrument,
                        IEnumerable<Instrument> posessionInstrument, ChooseMany<Instrument> posessionInstrumentFree,
                        ChooseMany<Language> languageFree)
    {
        this.name = name;
        this.skill = skill;
        this.money = money;
        this.equipment = equipment;
        this.instrument = instrument;
        this.posessionInstrument = posessionInstrument;
        this.posessionInstrumentFree = posessionInstrumentFree;
        this.languageFree = languageFree;
    }
}