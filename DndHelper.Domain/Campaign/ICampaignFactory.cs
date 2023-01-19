using System.Net;
using DndHelper.Infrastructure;

namespace DndHelper.Domain.Campaign;

public interface ICampaignFactory<TId, TStatusCode>
{
    Task<Result<ICampaign<Guid, TStatusCode>,TStatusCode>> CreateNew(string name, GameMaster gameMaster);

    Task<Result<ICampaign<Guid, TStatusCode>, TStatusCode>> GetExisting(Guid guid);

    Task<Result<IEnumerable<ICampaign<Guid, TStatusCode>>, TStatusCode>> GetMyCampaignsWhereIAmPlayer();

    Task<Result<IEnumerable<ICampaign<Guid, TStatusCode>>, TStatusCode>> GetMyCampaignsWhereIAmGameMaster();
}