using DndHelper.Domain.Dnd;
using DndHelper.Infrastructure;
using System.Net;

namespace DndHelper.Domain.Campaign;

public interface ICampaign<out TId, TStatus>
{
    TId Id { get; }
    IDictionary<(string UserId, Guid CharacterId), string> CharacterNames { get; }
    IDictionary<Guid, string> UserIds { get; }
    GameMaster GameMaster { get; }
    string Name { get; }

    Task<Result<TStatus>> Join(User<string> user, Character character);
    Task<Result<Character, TStatus>> GetCharacter(Guid characterGuid);
}