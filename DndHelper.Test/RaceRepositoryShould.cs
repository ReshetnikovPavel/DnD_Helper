using DndHelper.Domain.Dnd;
using DndHelper.Xml.Repositories;

namespace Tests;

[TestFixture]
public class RaceRepositoryShould
{
	XmlRaceRepository repository;
	[SetUp]
	public void SetUp()
    {
        var parser = new DndCompendiumParser();

        repository = new XmlRaceRepository(new DndCompendiumFactory(parser, new XmlLanguageRepository(), new XmlSpellRepository(parser)));
	}

	[Test]
	public void TestGetNames()
	{
		var expected = new HashSet<string> {"Эльф", "Драконорождённый", "Гном",
			"Полуэльф", "Полуорк", "Эльф", "Дварф", "Человек", 
			"Полурослик",
			"Тифлинг",};
        var actual = repository.GetNames().ToHashSet();
        actual.Should().Equal(expected);
	}

	[Test]
    public void TestGetSubraceNames()
	{
		var expected = new HashSet<string>() { "Дроу", "Высший", "Лесной" };
        var actual = repository.GetSubraceNames("Эльф").ToHashSet();
		actual.Should().Equal(expected);
    }

	[Test]
    public void TestGetRaceByName()
	{
        var actual = repository.GetRaceByName("Эльф", "Дроу");

        actual.Name.Should().Be("Эльф");
		actual.SubraceName.Should().Be("Дроу");
        actual.Speed.Value.Should().Be(30);
        actual.Languages.Should().BeEquivalentTo(new[] {new Language("Эльфийский"), new Language("Общий")});
        actual.Size.Should().Be(Size.Medium);
        actual.AbilityScoreBonuses.Should().BeEquivalentTo(new[]
        {
            new AbilityScoreBonus(AbilityName.Dexterity, 2),
            new AbilityScoreBonus(AbilityName.Charisma, 1)
        });
        actual.Feats.Should().BeEmpty();
        actual.Spells.Select(x => (x.spells.Name, x.level)).Should().BeEquivalentTo(new []{("Пляшущие огоньки", 1), ("Огонь фей", 3), ("Тьма", 5)});
        actual.WeaponsProficiencies.Should().BeEquivalentTo(new []{new Weapon("рапира"), new Weapon("короткий меч"), new Weapon("ручной арбалет")});
    }

    [Test]
    [TestCase("Эльф", "Дроу")]
    [TestCase("Эльф", "Лесной")]
    [TestCase("Полурослик", "Легконогий")]
    [TestCase("Человек", "Стандартный")]
    [TestCase("Человек", "Альтернативный")]
    [TestCase("Полуорк", null)]
    [TestCase("Полуэльф", null)]
    public void TestGetRaceByName_ShouldHaveSameRaceAndSubraceName(string raceName, string subraceName)
    {
        var actual = repository.GetRaceByName(raceName, subraceName);

        actual.Name.Should().Be(raceName);
        actual.SubraceName.Should().Be(subraceName);
    }

    [Test]
    [TestCase("Эльф", "Легконогий")]
    [TestCase("Дроу", "Эльф")]
    [TestCase("Полуэльф", "Дроу")]
    [TestCase("Wrong", "Wrong")]
    [TestCase("Эльф", null)]
    [TestCase(null, null)]
    [TestCase(null, "Альтернативный")]
    public void TestGetRaceByName_ShouldReturnNullWhenIncorrectNameOrSubraceName(string raceName, string subraceName)
    {
        var actual = repository.GetRaceByName(raceName, subraceName);
        actual.Should().BeNull();
    }

    [Test]
    [TestCase("Эльф", "Дроу", Size.Medium)]
    public void TestGetRaceByName_ShouldHaveRightSize(string raceName, string subraceName, Size size)
    {
        var actual = repository.GetRaceByName(raceName, subraceName);
        actual.Size.Should().Be(size);
    }

    [Test]
    [TestCase("Эльф", "Дроу", 30)]
    public void TestGetRaceByName_ShouldHaveRightSpeed(string raceName, string subraceName, int speed)
    {
        var actual = repository.GetRaceByName(raceName, subraceName);
        actual.Speed.Value.Should().Be(speed);
    }

    [Test]
    public void TestGetRaceByName_ShouldHaveRightLanguages()
    {
        var expected = new[] {new Language("Общий")};
        var actual = repository.GetRaceByName("Человек", "Стандартный");
        actual.Languages.Should().BeEquivalentTo(expected);
    }
}