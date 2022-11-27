using Domain;
using Domain.Repositories;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class ClassRepository_should
{
    private IClassRepository repository;

    [SetUp]
    public void SetUp()
    {
        repository = new XmlClassRepository(new DndCompendiumParser());
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
}