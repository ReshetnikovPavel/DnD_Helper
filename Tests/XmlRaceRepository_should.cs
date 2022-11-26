using System.Runtime.CompilerServices;
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
        var parser = new DndCompendiumParser();

        repository = new XmlRaceRepository(parser, new XmlLanguageRepository(), new XmlSpellRepository(parser));
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
}