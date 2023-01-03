using DndHelper.App.Authentication;
using DndHelper.App.Database;
using DndHelper.Domain.Dnd;

/* Unmerged change from project 'DndHelper.App (net6.0-maccatalyst)'
Before:
using DndHelper.App.Authentication;
After:
using DndHelper.Domain.Repositories;
*/

/* Unmerged change from project 'DndHelper.App (net6.0-ios)'
Before:
using DndHelper.App.Authentication;
After:
using DndHelper.Domain.Repositories;
*/

/* Unmerged change from project 'DndHelper.App (net6.0-android)'
Before:
using DndHelper.App.Authentication;
After:
using DndHelper.Domain.Repositories;
*/

/* Unmerged change from project 'DndHelper.App (net6.0-windows10.0.19041.0)'
Before:
using DndHelper.App.Authentication;
After:
using DndHelper.Domain.Repositories;
*/
using DndHelper.Domain.Repositories;

namespace DndHelper.App.Repositories;

public class DatabaseCharacterRepository<TUserId> : ICharacterRepository
{
    private readonly IDatabaseClient databaseClient;
    private readonly IAuthenticationProvider<TUserId> authenticationProvider;
    private User<TUserId> User => authenticationProvider.User;
    public DatabaseCharacterRepository(IDatabaseClient databaseClient, IAuthenticationProvider<TUserId> authenticationProvider)
    {
        this.databaseClient = databaseClient;
        this.authenticationProvider = authenticationProvider;
    }

    public async Task<Character> GetCharacter(Guid id)
    {
        return await GetCharacterQuery(id).GetAsync<Character>();
    }

    public async void PutCharacter(Character character)
    {
        await GetCharacterQuery(character).PutAsync(character);
    }

    public async Task<IEnumerable<Character>> GetCharacters()
    {
        return await GetChractersQuery().GetManyAsync<Character>();
    }

    private IDatabaseQuery GetCharacterQuery(Character character)
    {
        return GetCharacterQuery(character.Id);
    }

    private IDatabaseQuery GetCharacterQuery(Guid id)
    {
        return GetChractersQuery()
            .Child($"{id}");
    }

    private IDatabaseQuery GetChractersQuery()
    {
        return databaseClient
            .Child("Users")
            .Child($"{User.Id}")
            .Child("Characters");
    }
}