using System.Net;
using DndHelper.Infrastructure;

namespace DndHelper.Domain.Campaign;

public interface ICampaignFactory<TId, TStatusCode>
{
    Task<Result<ICampaign,TStatusCode>> CreateNew(string name, GameMaster gameMaster);

    Task<Result<ICampaign, TStatusCode>> GetExisting(Guid guid);

    Task<Result<IEnumerable<ICampaign>, TStatusCode>> GetMyCampaignsWhereIAmPlayer();

    Task<Result<IEnumerable<ICampaign>, TStatusCode>> GetMyCampaignsWhereIAmGameMaster();
}