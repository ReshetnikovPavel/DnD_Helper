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
        actual.Languages.Should().BeEquivalentTo("Эльфийский", "Общий");
    }
}