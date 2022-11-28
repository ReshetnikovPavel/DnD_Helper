using Domain;
using Domain.Repositories;
using Infrastructure;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class TestBackgroundlRepository
{
    private IBackgroundRepository repository;
    [SetUp]
    public void SetUp()
    {
        var parser = new DndCompendiumParser();
        repository = new XmlBackgroundRepository(parser, new DndCompendiumFactory(parser, new XmlLanguageRepository(), new XmlSpellRepository(parser)));
    }

    [Test]
    public void TestGetNames()
    {
        var expected = new List<string> {"Артист", "Гильдейский ремесленник"};
        var actual = repository.GetNames();
        actual.Should().Contain(expected);
    }

    [Test]
    public void TestGetBackground()
    {
        var name = "Артист";
        var expected = new Background(name, new List<SkillName>(){SkillName.Acrobatics, SkillName.Performance}, 15, new List<Equipment>(){new Equipment("подарок от поклонницы"), new Equipment("костюм")}, Enumerable.Empty<Instrument>(), new List<Instrument>(){new Instrument("Набор для грима")}, new ChooseMany<Instrument>(new []{new Instrument("музыкальный")}, 1), null);
        var actual = repository.GetBackground(name);
        actual.name.Should().Be(expected.name);
        actual.skill.Should().BeEquivalentTo(expected.skill);
        actual.money.Should().Be(expected.money);
        actual.equipment.Should().BeEquivalentTo(expected.equipment);
        actual.instrument.Should().BeEquivalentTo(expected.instrument);
        actual.posessionInstrument.Should().BeEquivalentTo(expected.posessionInstrument);
        actual.posessionInstrumentFree.Should().Be(expected.posessionInstrumentFree);
        actual.languageFree.Should().Be(expected.languageFree);
    }
}