using Infrastructure;

namespace Domain;

public class Background : ValueType<Background>, IDndObject
{
    public string name;
    public IEnumerable<SkillName> skill;
    public int money;
    public IEnumerable<Instrument> equipment;
    public IEnumerable<Instrument> instrument;
    public IEnumerable<Instrument> posessionInstrument;
    public ChooseMany<Instrument> posessionInstrumentFree;
    public int languageFree;

    public Background(string name, IEnumerable<SkillName> skill, int money,
                        IEnumerable<Instrument> equipment, IEnumerable<Instrument> instrument,
                        IEnumerable<Instrument> posessionInstrument, ChooseMany<Instrument> posessionInstrumentFree,
                        int languageFree)
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