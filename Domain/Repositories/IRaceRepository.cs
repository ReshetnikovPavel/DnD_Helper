namespace Domain.Repositories;

public interface IRaceRepository : IRepository
{
    Race GetRaceByName(string raceName, string subraceName);
    IEnumerable<string> GetSubraceNames(string raceName);
}