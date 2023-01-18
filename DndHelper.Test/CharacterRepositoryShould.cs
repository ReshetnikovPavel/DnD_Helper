﻿using DndHelper.App.RouteNavigation;
using DndHelper.App.ViewModels;
using DndHelper.Domain.Dnd;
using DndHelper.Firebase.Adapters;
using DndHelper.Firebase.Repositories;
using Firebase.Auth;
using Firebase.Database;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tests;

[TestFixture]
public class CharacterRepositoryShould
{
    private FirebaseCharacterRepository characterRepository;
    private FirebaseAuthProviderAdapter auth;
    [SetUp]
    public void SetUp()
    {
        var config = new FirebaseConfig("AIzaSyAsyhRQKmYdtXBaH8LOgFe_tgHWGRh6wJQ");
        auth = new FirebaseAuthProviderAdapter(config);
        var firebaseClient =
            new FirebaseClient("https://dndhelper-e695e-default-rtdb.asia-southeast1.firebasedatabase.app/");
        characterRepository = new FirebaseCharacterRepository(firebaseClient, auth);
    }


    [Test]
    public async Task ShouldLoadCharacter()
    {
        await auth.SignInWithEmailAndPassword("pasha.keyzet@yandex.ru", "Sin2x=2SinxCosx");
        var characters = await characterRepository.GetCharacter(Guid.Parse("6844fc89-3540-462e-9431-a3b800b3dc8e"));
       characters.Value.Should().NotBeNull();
    }
}