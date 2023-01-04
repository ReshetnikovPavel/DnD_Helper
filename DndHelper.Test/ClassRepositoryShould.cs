using DndHelper.Domain.Dnd;
using DndHelper.Domain.Repositories;
using DndHelper.Xml.Repositories;

namespace Tests;

[TestFixture]
public class ClassRepositoryShould
{
    private IClassRepository repository;

    [SetUp]
    public void SetUp()
    {
        var parser = new DndCompendiumParser();
        var languageRepository = new XmlLanguageRepository();
        var spellRepository = new XmlSpellRepository(parser);
        var factory = new DndCompendiumFactory(parser, languageRepository, spellRepository);
        repository = new XmlClassRepository(parser, factory);
    }

    [Test]
    public void GetClass_ShouldContainMainInfo()
    {
        var expected = new Class()
        {
            Name = "Бард",
            HitDice = new HitDice(new Dice(1, DiceName.D8)),
            AbilityNamesForSavingThrows = new[] {AbilityName.Dexterity, AbilityName.Charisma},
            SpellAbility = AbilityName.Charisma
        };
        var actual = repository.GetClass("Бард");

        actual.Name.Should().BeEquivalentTo(expected.Name);
        actual.HitDice.Should().BeEquivalentTo(expected.HitDice);
        actual.AbilityNamesForSavingThrows.Should().BeEquivalentTo(expected.AbilityNamesForSavingThrows);
        actual.SpellAbility.Should().Be(expected.SpellAbility);
    }

    [Test]
    public void GetClass_ShouldContainSpellSlotsTableWhenItHasOne()
    {
        var dndClass = repository.GetClass("Бард");
        dndClass.SpellSlotsTable.Should().NotBeNull();
    }

    [Test]
    public void GetClass_ShouldNotContainSpellSlotsTableWhenItDoesNotHaveOne()
    {
        var dndClass = repository.GetClass("Варвар");
        dndClass.SpellSlotsTable.Should().BeNull();
    }

    [Test]
    public void GetClass_ShouldContainFeatures()
    {
        var dndClass = repository.GetClass("Варвар");
        dndClass.LevelFeatures[1].Should().Contain(x => x.Name == "Ярость");
    }
}