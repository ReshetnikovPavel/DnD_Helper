using System.Net;
using DndHelper.App;
using Firebase.Database;
using Firebase.Database.Query;
using DndHelper.Domain.Repositories;
using DndHelper.Domain.Dnd;
using DndHelper.App.Authentication;
using DndHelper.Infrastructure;
using Newtonsoft.Json;


namespace DndHelper.Firebase.Repositories;

public class FirebaseCharacterRepository : ICharacterRepository<HttpStatusCode>
{
    private readonly FirebaseClient firebaseClient;
    private readonly IAuthenticationProvider<string> authenticationProvider;
    private User<string> User => authenticationProvider.User;

    public FirebaseCharacterRepository(FirebaseClient firebaseClient, IAuthenticationProvider<string> authenticationProvider)
    {
        this.firebaseClient = firebaseClient;
        this.authenticationProvider = authenticationProvider;
    }

    public Task<Result<Character, HttpStatusCode>> GetCharacter(Guid id)
    {
        return HandleError(async () => await GetCharacterQuery(id).OnceSingleAsync<Character>());
    }

    public Task<Result<HttpStatusCode>> PutCharacter(Character character)
    {
        var json = JsonConvert.SerializeObject(character);
        async void PutCharacterAction() => await GetCharacterQuery(character).PutAsync(json);

        return Task.FromResult(HandleError(PutCharacterAction));
    }

    public async Task<Result<IEnumerable<Character>, HttpStatusCode>> GetCharacters()
    {
        return await HandleError(async () => 
            (await GetUserQuery().OnceAsListAsync<Character>())
            .Select(x => x.Object));
    }

    private ChildQuery GetCharacterQuery(Character character)
    {
        return GetCharacterQuery(character.Id);
    }

    private ChildQuery GetCharacterQuery<TId>(TId id)
    {
        return GetUserQuery()
            .Child("Characters")
            .Child($"{id}");
    }

    private ChildQuery GetUserQuery()
    {
        return firebaseClient
            .Child("Users")
            .Child($"{User.Id}");
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