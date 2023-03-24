namespace FriendNet.REST.Storage;

public interface IStoreable
{
    public Guid Id { get; init; }
}

public interface IGambiarraDatabase<T> where T : IStoreable
{
    IEnumerable<T> List(Func<T, bool>? filterBy = null);
    T Add(T newItem);
    void Delete(Predicate<T> deleteBy);
    T Get(Guid Id);
}

public class InMemoryDatabase<T> : IGambiarraDatabase<T> where T : IStoreable
{
    private readonly HashSet<T> _storage = new HashSet<T>();
    
    public InMemoryDatabase(ICollection<T>? seed = null)
    {
        if (seed is not null)
        {
            _storage = new HashSet<T>(seed);
        }
    }
    public IEnumerable<T> List(Func<T, bool>? filterBy = null)
    {
        return filterBy is not null ? _storage.Where(filterBy) : _storage;
    }

    public T Add(T newItem)
    {
        _storage.Add(newItem);
        return newItem;
    }

    public void Delete(Predicate<T> deleteBy)
    {
        _storage.RemoveWhere(deleteBy);
    }

    public T Get(Guid Id)
    {
        var got = _storage.SingleOrDefault(t => t.Id.Equals(Id));
        return got ?? throw new KeyNotFoundException();
    }
}