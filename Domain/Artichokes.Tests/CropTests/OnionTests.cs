namespace Artichokes.UnitTests.Crops;

public class OnionTests{
    [Fact]
    public void MaybePlayedReturnsFalseIfNoArtichokesInHand()
    {
        Player player1 = new Player();
        player1.Hand.RemoveRange(0, 5);
        player1.Hand.Add(new Onion());

        Assert.True(player1.Hand[0].GetType() == typeof(Onion));
        Assert.False(player1.Hand[0].MayBePlayedBy(player1));
    }
    [Fact]
    public void MaybePlayedReturnsTrueIfOneArtichokeInHand()
    {
        Player player1 = new Player();
        player1.Hand.RemoveRange(0, 4);
        player1.Hand.Add(new Onion());

        Assert.True(player1.Hand[1].GetType() == typeof(Onion));
        Assert.True(player1.Hand[1].MayBePlayedBy(player1));
    }
    [Fact]
    public void MaybePlayedReturnsTrueIfMoreThanOneArtichokeInHand()
    {
        Player player1 = new Player();
        player1.Hand.Add(new Onion());

        Assert.True(player1.Hand[5].GetType() == typeof(Onion));
        Assert.True(player1.Hand[5].MayBePlayedBy(player1));
    }
    [Fact]
    public void PlayShouldRemoveOnionFromHand()
    {
        Player player1 = new Player();
        ICard onion = new Onion();
        player1.Hand.Add(onion);
        player1.Hand[5].Play(player1, "Joop");
        Assert.DoesNotContain(onion, player1.Hand);
        
    }
    [Fact]
    public void PlayShouldRemoveOneArtichokeFromHand()
    {
        Player player1 = new Player();
        ICard onion = new Onion();
        player1.Hand.Add(onion);
        player1.Hand[5].Play(player1, "Joop");
        Assert.True(player1.Hand.OfType<Artichoke>().Count()==4);
    }
    [Fact]
    public void PlayShouldAddOnionToDiscardPileOfSpecifiedPlayer()
    {
       
        Player player1 = new Player();
        ICard onion = new Onion();
        player1.Hand.Add(onion);
        player1.Hand[5].Play(player1, "Joop");
        Assert.Contains(onion, player1.PlayerToRight.DiscardPile.GetCards());
    }
}