using System.Net;
using DndHelper.Domain.Dnd;
using DndHelper.Infrastructure;


namespace DndHelper.Domain.Repositories;

public interface ICharacterRepository<TErrorStatus>
{
    Task<Result<Character, TErrorStatus>> GetCharacter(Guid id);
    Task<Result<Character, TErrorStatus>> GetCharacter(string userId, Guid characterId);
    Task<Result<TErrorStatus>> PutCharacter(Character character);
    Task<Result<IEnumerable<Character>, HttpStatusCode>> GetCharacters();
}