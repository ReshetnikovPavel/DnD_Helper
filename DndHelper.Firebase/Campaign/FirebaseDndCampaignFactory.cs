using DndHelper.Domain.Campaign;
using System.Xml.Linq;
using DndHelper.Domain.Dnd;
using DndHelper.Infrastructure;
using Firebase.Database;
using Firebase.Database.Query;
using System.Net;
using DndHelper.Domain.Repositories;

namespace DndHelper.Firebase.Campaign;

public class FirebaseDndCampaignFactory : ICampaignFactory<Guid, HttpStatusCode>
{
    private readonly FirebaseClient firebaseClient;
    private readonly ICharacterRepository<HttpStatusCode> characterRepository;

    public async Task<Result<ICampaign<Guid, HttpStatusCode>, HttpStatusCode>> CreateNew(string name, GameMaster gameMaster)
    {
        var campaign = (ICampaign<Guid, HttpStatusCode>) new FirebaseDndCampaign(Guid.NewGuid(), name, gameMaster, new Dictionary<(string, Guid), string>(), new Dictionary<Guid, string>())
        {
            FirebaseClient = firebaseClient,
            CharacterRepository = characterRepository
        };

        try
        {
            await GetCampaignQuery(campaign.Id).PutAsync(campaign);
            return Result.CreateSuccess<ICampaign<Guid, HttpStatusCode>, HttpStatusCode>(campaign);
        }
        catch (FirebaseException e)
        {
            return Result.CreateFailure<ICampaign<Guid, HttpStatusCode>, HttpStatusCode>(e.StatusCode, e);
        }
    }

    public Task<Result<ICampaign<Guid, HttpStatusCode>, HttpStatusCode>> GetExisting(Guid id)
    {
        return HandleError(async () => (ICampaign<Guid, HttpStatusCode>)await GetCampaignQuery(id).OnceSingleAsync<FirebaseDndCampaign>());
    }


    private ChildQuery GetCampaignQuery(Guid id)
    {
        return firebaseClient
            .Child("Campaigns")
            .Child($"{id}");
    }

    public FirebaseDndCampaignFactory(FirebaseClient firebaseClient, ICharacterRepository<HttpStatusCode> characterRepository)
    {
        this.firebaseClient = firebaseClient;
        this.characterRepository = characterRepository;
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