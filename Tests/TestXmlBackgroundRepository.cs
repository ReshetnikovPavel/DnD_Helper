using System.Xml.Linq;
using Domain;
using Domain.Repositories;
using Infrastructure;
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
        var parser = new DndCompendiumParser();
        languageRepository = new XmlLanguageRepository();
        var spellRepository = new XmlSpellRepository(parser);
        var factory = new DndCompendiumFactory(parser, languageRepository, spellRepository);
        repository = new XmlBackgroundRepository(parser, factory);
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
        var expected = new Background(name, new List<SkillName>() {SkillName.Acrobatics, SkillName.Performance}, 15,
            new List<Equipment>() {new Equipment("подарок от поклонницы"), new Equipment("костюм")}, null,
            new List<Instrument>() {new Instrument("Набор для грима")}, null,
            new ChooseMany<Language>(null, 1));
        var actual = repository.GetBackground(name);
        actual.instrument.Should().BeEquivalentTo(expected.instrument);
        actual.posessionInstrument.Should().BeEquivalentTo(expected.posessionInstrument);
        actual.posessionInstrumentFree.Should().Be(expected.posessionInstrumentFree);
    }
}