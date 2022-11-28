/*
using System.Xml.Linq;
using Domain;
using Domain.Repositories;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class TestBackgroundlRepository
{
    private IBackgroundRepository repository;
    private ILanguageRepository languageRepository;
    [SetUp]
    public void SetUp()
    {
        repository = new XmlBackgroundRepository(new DndCompendiumParser());
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
        var expected = new Background(name, new List<SkillName>(){SkillName.Acrobatics, SkillName.Performance}, 15, new List<Equipment>(){new Equipment("подарок от поклонницы"), new Equipment("костюм")}, null, new List<Instrument>(){new Instrument("Набор для грима")}, null, 1);
        var actual = repository.GetBackground(name);
        actual.instrument.Should().BeEquivalentTo(expected.instrument);
        actual.posessionInstrument.Should().BeEquivalentTo(expected.posessionInstrument);
        actual.posessionInstrumentFree.Should().Be(expected.posessionInstrumentFree);
        actual.languageFree.Should().Be(expected.languageFree);

    }
}
*/