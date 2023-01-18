using System.Net;
using DndHelper.Infrastructure;

namespace DndHelper.Domain.Campaign;

public interface ICampaignFactory<TId, TStatusCode>
{
    Task<Result<ICampaign<Guid>,TStatusCode>> CreateNew(string name, GameMaster gameMaster);

    Task<Result<ICampaign<Guid>, TStatusCode>> GetExisting(Guid guid);
}