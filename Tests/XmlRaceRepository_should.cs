using Domain;
using Domain.Repositories;
using FluentAssertions;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class XmlRaceRepository_should
{
	XmlRaceRepository repository;
	[SetUp]
	public void SetUp()
	{
		repository = new XmlRaceRepository(new DndCompendiumParser());
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
        actual.Spells.Should().BeEquivalentTo(new []{new Spell("Пляшущие огоньки", 1), new Spell("Огонь фей", 3), new Spell("Тьма", 5)});
        actual.WeaponsProficiencies.Should().BeEquivalentTo(new []{new Weapon("рапира"), new Weapon("короткий меч"), new Weapon("ручной арбалет")});
    }
}