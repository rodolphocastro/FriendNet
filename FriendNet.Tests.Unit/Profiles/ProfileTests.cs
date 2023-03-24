using FriendNet.REST.Profiles;

namespace FriendNet.Tests.Unit.Profiles;

public class ProfileTests
{
    [Fact]
    public void GivenANameAndABioAndADateOfBirth_WhenAProfileIsConstructed_ThenAnObjectIsCreated()
    {
        // Given
        const string name = "Rodolpho Alves";
        const string bio = @"
            Runner (5k, 10k, 21k)
            Cyclist (50k, 100k)
            Swimmer (2k)
            I like to code it out in my free time
        ";
        var dateOfBirth = DateOnly.Parse("1993-04-10");
        
        // When
        Profile got = new(name, bio, dateOfBirth);
        
        // Then
        Assert.NotNull(got);
        Assert.Equal(name, got.Name);
        Assert.Equal(bio, got.Biography);
        Assert.Equal(dateOfBirth, got.Birthday);
    }
}