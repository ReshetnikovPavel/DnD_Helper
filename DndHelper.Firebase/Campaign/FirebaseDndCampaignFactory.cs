using DndHelper.Domain.Campaign;
using System.Xml.Linq;
using DndHelper.Domain.Dnd;
using DndHelper.Infrastructure;
using Firebase.Database;
using Firebase.Database.Query;
using System.Net;

namespace DndHelper.Firebase.Campaign;

public class FirebaseDndCampaignFactory : ICampaignFactory<Guid, HttpStatusCode>
{
    private readonly FirebaseClient firebaseClient;

    public async Task<Result<ICampaign<Guid>, HttpStatusCode>> CreateNew(string name, GameMaster gameMaster)
    {
        var campaign = (ICampaign<Guid>) new FirebaseDndCampaign(Guid.NewGuid(), name, gameMaster, new List<Character>())
        {
            FirebaseClient = firebaseClient
        };

        try
        {
            await GetCampaignQuery(campaign.Id).PutAsync(campaign);
            return Result.CreateSuccess<ICampaign<Guid>, HttpStatusCode>(campaign);
        }
        catch (FirebaseException e)
        {
            return Result.CreateFailure<ICampaign<Guid>, HttpStatusCode>(e.StatusCode, e);
        }
    }

    public Task<Result<ICampaign<Guid>, HttpStatusCode>> GetExisting(Guid id)
    {
        return HandleError(async () => (ICampaign<Guid>)await GetCampaignQuery(id).OnceSingleAsync<FirebaseDndCampaign>());
    }


    private ChildQuery GetCampaignQuery(Guid id)
    {
        return firebaseClient
            .Child("Campaigns")
            .Child($"{id}");
    }

    public FirebaseDndCampaignFactory(FirebaseClient firebaseClient)
    {
        this.firebaseClient = firebaseClient;
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