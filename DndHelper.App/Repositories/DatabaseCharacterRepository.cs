using DndHelper.Domain.Repositories;
using DndHelper.Domain.Dnd;
using DndHelper.App.Database;

namespace DndHelper.App.Repositories;

public class DatabaseCharacterRepository : ICharacterRepository
{
    private readonly IDatabaseClient databaseClient;
    private readonly User<string> user;
    public DatabaseCharacterRepository(IDatabaseClient databaseClient, User<string> user)
    {
        this.databaseClient = databaseClient;
        this.user = user;
    }

    public async Task<Character> GetCharacter<TId>(TId id)
    {
        return await GetCharacterQuery(id).GetAsync<Character>();
    }

    public async void PutCharacter(Character character)
    {
        await GetCharacterQuery(character).PutAsync(character);
    }

    private IDatabaseQuery GetCharacterQuery(Character character)
    {
        return GetCharacterQuery(character.Id);
    }

    private IDatabaseQuery GetCharacterQuery<TId>(TId id)
    {
        return databaseClient
            .Child("Users")
            .Child($"{user.Id}")
            .Child("Characters")
            .Child($"{id}");
    }
}