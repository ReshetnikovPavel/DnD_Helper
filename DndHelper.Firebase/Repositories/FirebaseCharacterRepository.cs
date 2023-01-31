using System.Net;
using Firebase.Database;
using Firebase.Database.Query;
using DndHelper.Domain.Repositories;
using DndHelper.Domain.Dnd;
using DndHelper.Infrastructure;
using Newtonsoft.Json;
using DndHelper.Infrastructure.Authentication;

namespace DndHelper.Firebase.Repositories;

public class FirebaseCharacterRepository : ICharacterRepository<HttpStatusCode>
{
    private readonly FirebaseClient firebaseClient;
    private readonly IUserProvider<string> userProvider;
    private User<string> User => userProvider.User;

    public FirebaseCharacterRepository(FirebaseClient firebaseClient, IUserProvider<string> authenticationProvider)
    {
        this.firebaseClient = firebaseClient;
        this.userProvider = authenticationProvider;
    }

    public Task<Result<Character, HttpStatusCode>> GetCharacter(Guid id)
    {
        return HandleError(async () => await GetCharacterQuery(id).OnceSingleAsync<Character>());
    }

    public Task<Result<Character, HttpStatusCode>> GetCharacter(string userId, Guid characterId)
    {
        return HandleError(async () => await GetCharacterQuery(userId, characterId).OnceSingleAsync<Character>());
    }

    public Task<Result<HttpStatusCode>> PutCharacter(Character character)
    {
        var json = JsonConvert.SerializeObject(character);
        async void PutCharacterAction() => await GetCharacterQuery(character).PutAsync(json);

        return Task.FromResult(HandleError(PutCharacterAction));
    }

    public async Task<Result<IEnumerable<Character>, HttpStatusCode>> GetCharacters()
    {
        var res = await HandleError(async () =>
            await GetUserQuery()
                .Child("Characters")
                .OnceSingleAsync<Dictionary<string,Character>>());

        if (res.TryGetValue(out var idToCharacter))
            return idToCharacter.Values;
        return Result.CreateFailure<IEnumerable<Character>, HttpStatusCode>(res.Status);
    }

    private ChildQuery GetCharacterQuery(Character character)
    {
        return GetCharacterQuery(character.Id);
    }

    private ChildQuery GetCharacterQuery(Guid id)
    {
        return GetUserQuery()
            .Child("Characters")
            .Child($"{id}");
    }

    private ChildQuery GetCharacterQuery(string userId, Guid id)
    {
        return GetUserQuery(userId)
            .Child("Characters")
            .Child($"{id}");
    }

    private ChildQuery GetUserQuery(string id)
    {
        return firebaseClient
            .Child("Users")
            .Child($"{id}");
    }
    private ChildQuery GetUserQuery()
    {
        return GetUserQuery(User.Id);
    }
    private static async Task<Result<T, HttpStatusCode>> HandleError<T>(Func<Task<T>> interactWithFirebase)
    {
        try
        {
            return await interactWithFirebase();
        }
        catch (FirebaseException e)
        {
            return Result.CreateFailure<T, HttpStatusCode>(e.StatusCode, e);
        }
    }

    private static Result<HttpStatusCode> HandleError(Action interactWithFirebase)
    {
        try
        {
            interactWithFirebase();
            return Result.CreateSuccess<HttpStatusCode>();
        }
        catch (FirebaseException e)
        {
            return Result.CreateFailure(e.StatusCode, e);
        }
    }
}