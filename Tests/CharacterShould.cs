using Domain;
using Domain.Repositories;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class CharacterShould
{
    [Test]
    public void TestAplayRace()
    {
        var race = new Race();
        var character = new Character(new Guid(18, 0, 0, new byte[8]));
        race.Name = "Драконнорождённый";
        race.Size = Size.Medium;
        race.Speed = new Speed(30);
        race.AbilityScoreBonuses = new List<AbilityScoreBonus>(){new AbilityScoreBonus(AbilityName.Strength, 2), new AbilityScoreBonus(AbilityName.Charisma, 1)};
        race.Languages = new List<Language>(){new Language("Драконий"), new Language("Общий")};

        character.Race = race;
        character.AplayRace();
        character.Size.Should().Be(race.Size);
        character.Speed.Should().Be(race.Speed);
        character.AbilityScoreBonuses.Should().BeEquivalentTo(race.AbilityScoreBonuses);
        character.Languages.Should().BeEquivalentTo(race.Languages);    
    }
}