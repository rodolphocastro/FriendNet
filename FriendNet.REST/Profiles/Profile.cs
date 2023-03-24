namespace FriendNet.REST.Profiles;

/// <summary>
/// Representation of an User's profile in the network.
/// </summary>
public class Profile
{
    public Profile(string name, string bio, DateOnly dateOfBirth)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Biography = bio ?? throw new ArgumentNullException(nameof(bio));
        Birthday = dateOfBirth;
    }

    public string Name { get; protected set; }
    public string Biography { get; protected set; }
    public DateOnly Birthday { get; protected set; }
}