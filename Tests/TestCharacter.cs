using Domain;
using Domain.Repositories;
using NUnit.Framework;

namespace Tests;

[TestFixture]
public class TestCharacter
{
    [Test]

    public void TestAplayRace()
    {
        var race = new Race();
        var character = new Character(new Guid());
    }
}