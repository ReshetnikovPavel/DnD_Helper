namespace Domain.Repositories;

public interface IClassRepository : IRepository
{
    Class GetClass(string name);
}