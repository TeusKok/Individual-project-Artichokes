namespace Artichokes.UnitTests.Crops;

public class BellpepperTests
{
    [Fact]
    public void MaybePlayedReturnsFalseIfThereAreNoCardsOnYourDiscardPile()
    {
        Player player1 = new Player();
        player1.Hand.Add(new Bellpepper());
        Assert.False(player1.Hand[5].MayBePlayedBy(player1));
    }
    [Fact]
    public void MaybePlayedReturnsTrueIfThereIsAtLeastOneCardsOnYourDiscardPile()
    {
        Player player1 = new Player();
        player1.Hand.Add(new Bellpepper());
        player1.DiscardPile.Add(new Potato());
        Assert.True(player1.Hand[5].MayBePlayedBy(player1));
    }
    [Fact]
    public void GetOptionsShouldGiveStringWithCardsFromDiscardPile()
    {
        Player player1 = new Player("Piet/aaaaaB/0/pCc/0/1|Joop/ppppp/0/0/0/0|Jan/aaaaa/0/0/0/0|Jaap/aaaaa/0/0/0/0|0|0");

        string option = player1.Hand[5].GetOption(player1);
        string[] Answers = option.Split("|")[1].Split("/");

        Assert.Equal("Potato", Answers[0].Split(":")[1].Trim());
        Assert.Equal("1", Answers[0].Split(":")[0].Trim());

        Assert.Equal("2: Corn", Answers[1].Trim());
        Assert.Equal("3: Carrot", Answers[2].Trim());
    }
    [Fact]
    public void PlayShouldMoveSelectedCardFromDiscardPileToTopOfDrawPile()
    {
        Player player1 = new Player("Piet/aaaaaB/0/pCc/0/1|Joop/ppppp/0/0/0/0|Jan/aaaaa/0/0/0/0|Jaap/aaaaa/0/0/0/0|0|0");

        string option = player1.Hand[5].GetOption(player1);
        string[] Answers = option.Split("|")[1].Split("/");
        player1.Hand[5].Play(player1, Answers[0]);

        Assert.True(player1.DrawPile.GetTopCard().GetType() == typeof(Potato));
        Assert.True(player1.DiscardPile.GetNumberOfCards() == 2);
    }
    [Fact]
    public void PlayShouldDoNothinIfCardMayNotBePlayed()
    {
        Player player1 = new Player("Piet/aaaaaB/0/0/0/1|Joop/ppppp/0/0/0/0|Jan/aaaaa/0/0/0/0|Jaap/aaaaa/0/0/0/0|0|0");

        string option = player1.Hand[5].GetOption(player1);
        string[] Answers = option.Split("|")[1].Split("/");
        player1.Hand[5].Play(player1, Answers[0]);

        Assert.True(player1.DrawPile.GetNumberOfCards() == 0);
        Assert.True(player1.DiscardPile.GetNumberOfCards() == 0 );
    }
}