namespace Domain.Repositories;

public interface IRepository
{
	public IEnumerable<string> GetNames();
}