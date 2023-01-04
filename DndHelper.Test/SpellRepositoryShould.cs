using DndHelper.Domain.Dnd;
using DndHelper.Domain.Repositories;
using DndHelper.Xml.Repositories;

namespace Tests;

[TestFixture]
public class TestSpellRepository
{
    private ISpellRepository repository;
    [SetUp]
    public void SetUp()
    {
        repository = new XmlSpellRepository(new DndCompendiumParser());
    }

    [Test]
    public void TestGetNames()
    {
        var expected = new List<string> {"Злая насмешка", "Брызги кислоты"};
        var actual = repository.GetNames();
        actual.Should().Contain(expected);
    }

    [Test]
    public void TestGetNamesWithSchool_ShouldHaveSpellsFromThatClass()
    {
        var expected = new List<string>(){"Волшебная рука", "Брызги кислоты"};
        var actual = repository.GetNamesForClass("Волшебник");
        actual.Should().Contain(expected);
    }

    [Test]
    public void TestGetNamesWithSchool_ShouldNotHaveSpellsFromAnotherClass()
    {
        var expected = new List<string>() {"Злая насмешка", "Дубинка"};
        var actual = repository.GetNamesForClass("Волшебник");
        actual.Should().NotContain(expected);
    }

    [Test]
    public void TestGetSpell()
    {
        var name = "Брызги кислоты";
        var expected = new Spell(name, 0, new HashSet<SpellComponent> { SpellComponent.Verbal, SpellComponent.Somatic }, "Призыв", "1 действие", new []{ "Волшебник", "Изобретатель", "Чародей"});
        var actual = repository.GetSpell(name);
        actual.ClassNames.Should().BeEquivalentTo(expected.ClassNames);
        actual.Components.Should().BeEquivalentTo(expected.Components);
        actual.Time.Should().Be(expected.Time);
        actual.School.Should().BeEquivalentTo(expected.School);
        actual.Description.Should().BeEquivalentTo(expected.Description);
        actual.ClassNames.Should().BeEquivalentTo(expected.ClassNames);
        actual.Level.Should().Be(expected.Level);

    }
}