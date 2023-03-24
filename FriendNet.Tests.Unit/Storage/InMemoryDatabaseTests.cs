using FriendNet.REST.Storage;

namespace FriendNet.Tests.Unit.Storage;

public record Dummy(Guid Id, string Name) : IStoreable;

public class InMemoryDatabaseTests
{
    private readonly IGambiarraDatabase<Dummy> _subject = new InMemoryDatabase<Dummy>();

    [Fact]
    public void GivenAnEmptyDatabase_WhenListIsInvoked_ThenAnEmptySetIsReturned()
    {
        // Given
        
        // When
        var got = _subject.List();
        
        // Then
        Assert.NotNull(got);
        Assert.Empty(got);
    }
    
    [Fact]
    public void GivenADummy_WhenAddIsInvoked_ThenTheSetIsMutated()
    {
        // Given
        Dummy newDummy = new(Guid.NewGuid(), "Cobaia");
        
        // When
        _subject.Add(newDummy);
        var got = _subject.List();
        
        // Then
        Assert.NotNull(got);
        Assert.NotEmpty(got);
    }
    
    [Fact]
    public void GivenADummy_WhenDeleteIsInvoked_ThenTheSetIsEmpty()
    {
        // Given
        Dummy newDummy = new(Guid.NewGuid(), "Cobaia");
        
        // When
        _subject.Add(newDummy);
        _subject.Delete(t => t == newDummy);
        var got = _subject.List();
        
        // Then
        Assert.NotNull(got);
        Assert.Empty(got);
    }
    
    [Fact]
    public void GivenADummy_WhenGetIsInvoked_ThenDummyIsReturned()
    {
        // Given
        Dummy newDummy = new(Guid.NewGuid(), "Cobaia");
        
        // When
        _subject.Add(newDummy);
        var got = _subject.Get(newDummy.Id);
        
        // Then
        Assert.NotNull(got);
        Assert.Equal(newDummy, got);
    }
}