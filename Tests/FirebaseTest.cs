using Domain;
using Domain.Repositories;
using NUnit.Framework;
using Infrastructure;
using Newtonsoft.Json;

namespace Tests;

[TestFixture]
public class FirebaseTest
{
    private static FirebaseCharacterRepository repository;
    private static Character character;
    [SetUp]
    public static void SetUp()
    {
        var url = new FirebaseUrl(@"https://dndhelper-e695e-default-rtdb.asia-southeast1.firebasedatabase.app/");
        character = new Character(Guid.Parse("cf85d53b-14ff-4a1f-9af8-594cb138d0a6"));
        repository = new FirebaseCharacterRepository(url, new User(Guid.Parse("076afccf-72ed-40e5-bda4-d921f27caf70")));
    }

    [Test]
    public Task ShouldPutCharacter()
    {
        repository.PutCharacter(new Character(Guid.NewGuid()));
        return Task.CompletedTask;
    }

    [Test]
    public async Task ShouldGetCharacter()
    {
        var receivedCharacter = await repository.GetCharacter(Guid.Parse("706acb2f-a182-4264-845c-af6c8ce64c6d"));
        receivedCharacter.Should().NotBeNull();
    }
}