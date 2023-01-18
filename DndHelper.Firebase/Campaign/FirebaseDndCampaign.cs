using DndHelper.Infrastructure;
using DndHelper.Domain.Campaign;
using DndHelper.Domain.Dnd;
using Firebase.Database;
using Newtonsoft.Json;
using System.Net;
using DndHelper.Domain.Repositories;
using DndHelper.Firebase.Repositories;
using Firebase.Database.Query;

namespace DndHelper.Firebase.Campaign;

public class FirebaseDndCampaign : Entity<Guid>, ICampaign<Guid, HttpStatusCode>
{
    internal FirebaseClient FirebaseClient { get; set; }
    internal ICharacterRepository<HttpStatusCode> CharacterRepository { get; set; }
    
    public FirebaseDndCampaign(Guid id, string name, GameMaster gameMaster, IDictionary<(string,Guid), string> characterNames, IDictionary<Guid, string> userIds) : base(id)
    {
        Name = name;
        GameMaster = gameMaster;
        CharacterNames = characterNames;
        UserIds = userIds;
    }

    public new Guid Id => base.Id;
    public IDictionary<(string UserId, Guid CharacterId), string> CharacterNames { get; }
    public IDictionary<Guid, string> UserIds { get; }
    public GameMaster GameMaster { get; set; }
    public string Name { get; set; }
    public async Task<Result<HttpStatusCode>> Join(User<string> user, Character character)
    {
        try
        {
            await GetCharacterIdsQuery(Id).PutAsync(character.Id);
            CharacterNames[(user.Id, character.Id)] = character.Name;
            UserIds[character.Id] = user.Id;
            return Result.CreateSuccess<HttpStatusCode>();
        }
        catch (FirebaseException e)
        {
            return Result.CreateFailure(e.StatusCode, e);
        }
    }

    public Task<Result<Character, HttpStatusCode>> GetCharacter(Guid characterGuid)
    {
        return CharacterRepository.GetCharacter(UserIds[characterGuid], characterGuid);
    }

    private ChildQuery GetCharacterIdsQuery(Guid id)
    {
        return FirebaseClient
            .Child("Campaigns")
            .Child($"{id}")
            .Child("CharacterIds");
    }
}