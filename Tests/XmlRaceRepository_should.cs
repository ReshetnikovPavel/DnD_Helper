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
		repository = new XmlRaceRepository();
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
}