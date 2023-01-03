using DndHelper.App.Database;
using Firebase.Database.Query;

namespace DndHelper.Firebase.Adapters;

public class ChildQueryAdapter : IDatabaseQuery
{
    private readonly ChildQuery childQuery;

    public ChildQueryAdapter(ChildQuery childQuery)
    {
        this.childQuery = childQuery;
    }

    public IDatabaseQuery Child(string name)
    {
        return new ChildQueryAdapter(childQuery.Child(name));
    }

    public Task<T> GetAsync<T>()
    {
        return childQuery.OnceSingleAsync<T>();
    }

    public async Task<IEnumerable<T>> GetManyAsync<T>()
    {
        return (await childQuery.OnceAsListAsync<T>()).Select(x => x.Object);
    }

    public Task PutAsync<T>(T obj)
    {
        return childQuery.PutAsync(obj);
    }
}