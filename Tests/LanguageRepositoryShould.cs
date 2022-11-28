using Domain.Repositories;

namespace Tests;

public class LanguageRepositoryShould
{
    XmlLanguageRepository repository;
    [SetUp]
    public void SetUp()
    {
        repository = new XmlLanguageRepository();
    }

    [Test]
    public void TestGetNames()
    {
        var expected = new HashSet<string> { "Великаний", "Гномий", "Гоблинский", "Дварфский", "Общий", "Орочий", "Полуросликов", "Эльфийский",  "Бездны", "Глубинная речь",  "Драконий", "Инфернальный", "Небесный", "Первичный", "Подземный", "Сильван" };
        var actual = repository.GetNames().ToHashSet();
        actual.Should().Equal(expected);
    }
}