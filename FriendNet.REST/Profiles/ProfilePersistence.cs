using FriendNet.REST.Storage;

namespace FriendNet.REST.Profiles;

public class ProfilePersistence : Profile, IStoreable
{
    public ProfilePersistence(Guid id, string name, string bio, DateOnly dateOfBirth) : base(name, bio, dateOfBirth)
    {
        Id = id;
    }

    public Guid Id { get; init; }
}

public static class ProfilePersistenceExtensions
{
    public static ProfilePersistence ToStoreable(this Profile subject)
    {
        return new ProfilePersistence(Guid.NewGuid(), subject.Name, subject.Biography, subject.Birthday);
    }

    public static Profile ToProfile(this ProfilePersistence subject)
    {
        return new Profile(subject.Name, subject.Biography, subject.Birthday);
    }
}