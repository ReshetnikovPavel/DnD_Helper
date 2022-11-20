namespace Domain.Repositories;

public interface IRaceRepository : IRepository
{
	Race GetRaceByName(string name);
}