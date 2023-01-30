using DndHelper.Domain.Campaign;
using System.Xml.Linq;
using DndHelper.Domain.Dnd;
using DndHelper.Infrastructure;
using Firebase.Database;
using Firebase.Database.Query;
using System.Net;
using DndHelper.Domain.Repositories;
using DndHelper.Infrastructure.Authentication;

namespace DndHelper.Firebase.Campaign;

public class FirebaseDndCampaignFactory : ICampaignFactory<Guid, HttpStatusCode>
{
    private readonly FirebaseClient firebaseClient;
    private readonly ICharacterRepository<HttpStatusCode> characterRepository;
    private readonly IUserProvider<string> userProvider;

    public async Task<Result<ICampaign, HttpStatusCode>> CreateNew(string name, GameMaster gameMaster)
    {
        var campaign = (ICampaign) new FirebaseDndCampaign(Guid.NewGuid(), name, gameMaster, new Dictionary<(string, Guid), string>(), new Dictionary<Guid, string>())
        {
            FirebaseClient = firebaseClient,
            CharacterRepository = characterRepository
        };

        try
        {
            await GetCampaignQuery(campaign.Id).PutAsync(campaign);
            await GetAsGameMasterCampaignsQuery(userProvider.User.Id).PutAsync(campaign.Id);
            return Result.CreateSuccess<ICampaign, HttpStatusCode>(campaign);
        }
        catch (FirebaseException e)
        {
            return Result.CreateFailure<ICampaign, HttpStatusCode>(e.StatusCode, e);
        }
    }

    public Task<Result<ICampaign, HttpStatusCode>> GetExisting(Guid id)
    {
        return HandleError(async () => (ICampaign)await GetCampaignQuery(id).OnceSingleAsync<FirebaseDndCampaign>());
    }

    public async Task<Result<IEnumerable<ICampaign>, HttpStatusCode>> GetMyCampaignsWhereIAmPlayer()
    {
        var ids = await GetAsPlayerCampaignsQuery(userProvider.User.Id).OnceAsync<string>();
        return await GetCampaignsList(ids);
    }

    public async Task<Result<IEnumerable<ICampaign>, HttpStatusCode>> GetMyCampaignsWhereIAmGameMaster()
    {
        var ids = await GetAsGameMasterCampaignsQuery(userProvider.User.Id).OnceAsync<string>();
        return await GetCampaignsList(ids);
    }

    private async Task<Result<IEnumerable<ICampaign>, HttpStatusCode>> GetCampaignsList(IReadOnlyCollection<FirebaseObject<string>> ids)
    {
        var list = new List<ICampaign>();
        foreach (var firebaseObject in ids)
        {
            var id = Guid.Parse(firebaseObject.Key);
            if ((await GetExisting(id)).TryGetValue(out var campaign))
                list.Add(campaign);
        }
        return list;
    }


    private ChildQuery GetCampaignQuery(Guid id)
    {
        return firebaseClient
            .Child("Campaigns")
            .Child($"{id}");
    }

    public FirebaseDndCampaignFactory(FirebaseClient firebaseClient, ICharacterRepository<HttpStatusCode> characterRepository, IUserProvider<string> authenticationProvider)
    {
        this.firebaseClient = firebaseClient;
        this.characterRepository = characterRepository;
        this.userProvider = authenticationProvider;
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

    private ChildQuery GetAsPlayerCampaignsQuery(string id)
    {
        return firebaseClient
            .Child("Users")
            .Child($"{id}")
            .Child("CampaignsAsPlayer");
    }

    private ChildQuery GetAsGameMasterCampaignsQuery(string id)
    {
        return firebaseClient
            .Child("Users")
            .Child($"{id}")
            .Child("CampaignsAsGameMaster");
    }
}
