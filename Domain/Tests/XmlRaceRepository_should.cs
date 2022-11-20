using Domain.Repositories;
using FluentAssertions;
using NUnit.Framework;

namespace Domain.Tests;

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
		var expected = new List<string> {"Эльф (Дроу)", "Драконорождённый", "Гном (Лесной)",
			"Полу-эльф", "Полу-орк", "Эльф(Высший)", "Дварф (Холмовой)", "Человек", 
			"Человек (Альтернатива)", "Полурослик (Легконогий)", "Дварф (Горный)",
			"Гном (Скальный)", "Полурослик (Коренастый)", "Тифлинг", "Эльф (Лесной)"};
		var actual = repository.GetNames();
		actual.Should().Equal(expected);
	}
}