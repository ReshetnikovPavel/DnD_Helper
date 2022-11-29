
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
        var parser = new DndCompendiumParser();
        var languageRepository = new XmlLanguageRepository();
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
    public void TestGet()
    {
        var names = repository.GetNames();
        var list = new List<Background>();
        foreach (var name in names)
        {
            list.Add(repository.GetBackground(name));
        }
        list.Should().BeNull();
    }
}
