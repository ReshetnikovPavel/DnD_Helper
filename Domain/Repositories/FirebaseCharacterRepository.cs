using Firebase.Database;
using Firebase.Database.Query;
using Infrastructure;


namespace Domain.Repositories;

public class FirebaseCharacterRepository : ICharacterRepository
{
    private readonly FirebaseClient firebaseClient;
    private readonly User user;
    public FirebaseCharacterRepository(FirebaseClient client, User user)
    {
        firebaseClient = client;
        this.user = user;
    }

    public async Task<Character> GetCharacter<TId>(TId id)
    {
        return await GetCharacterQuery(id).OnceSingleAsync<Character>();
    }

    public async void PutCharacter(Character character)
    {
        await GetCharacterQuery(character).PutAsync(character);
    }

    private ChildQuery GetCharacterQuery(Character character)
    {
        return GetCharacterQuery(character.Id);
    }

    private ChildQuery GetCharacterQuery<TId>(TId id)
    {
        return firebaseClient
            .Child("Users")
            .Child($"{user.Id}")
            .Child("Characters")
            .Child($"{id}");
    }
}