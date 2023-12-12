namespace Artichokes.UnitTests.Crops;

public class LeekTests
{
    [Fact]
    public void GetOptionsGivesTheNamesOfTheOtherPlayers()
    {
        Player player1 = new Player();
        player1.Hand.Add(new Leek());
        string option = player1.Hand[5].GetOption(player1);
        string[] Answers = option.Split("|")[1].Split("/");

        Assert.Equal("Joop", Answers[0].Trim());
        Assert.Equal("Jan", Answers[1].Trim());
        Assert.Equal("Jaap", Answers[2].Trim());
    }
    [Fact]
    public void GetOptionsGivesOnlyTheNamesOfTheOtherPlayersThatHaveCardsInTheirDrawOrDiscardPiles()
    {
        Player player1 = new Player("Piet/aaaaal/0/pCc/0/1|Joop/ppppp/ppppp/ppppp/0/0|Jan/aaaaa/0/0/0/0|Jaap/aaaaa/ppp/pppp/0/0|0|0");
        string option = player1.Hand[5].GetOption(player1);
        string[] Answers = option.Split("|")[1].Split("/");

        Assert.Equal("Joop", Answers[0].Trim());
        Assert.Equal("Jaap", Answers[1].Trim());
    }
    [Fact]
    public void PlayShouldAddTheTopCardOfTheDrawPileOfTheSelectedPlayerToYourHandIfTheTopCardIsNotAnArtichoke()
    {
        Player player1 = new Player("Piet/aaaaal/0/pCc/0/1|Joop/ppppp/paaaa/0/0/0|Jan/aaaaa/0/0/0/0|Jaap/aaaaa/ppp/pppp/0/0|0|0");
        string option = player1.Hand[5].GetOption(player1);
        string[] Answers = option.Split("|")[1].Split("/");
        player1.Hand[5].Play(player1, Answers[0]);

        Assert.Equal(7,player1.Hand.Count);
        Assert.Equal(4,player1.PlayerToRight.DrawPile.GetNumberOfCards());
        Assert.IsType<Potato>(player1.Hand[6]);
    }
    [Fact]
    public void PlayShouldAddTheTopCardOfTheDrawPileOfTheSelectedPlayerToTheirDiscardPileIfTheTopCardIsAnArtichoke()
    {
        Player player1 = new Player("Piet/aaaaal/0/pCc/0/1|Joop/ppppp/apppp/0/0/0|Jan/aaaaa/0/0/0/0|Jaap/aaaaa/ppp/pppp/0/0|0|0");
        string option = player1.Hand[5].GetOption(player1);
        string[] Answers = option.Split("|")[1].Split("/");
        player1.Hand[5].Play(player1, Answers[0]);

        Assert.Equal(6,player1.Hand.Count);
        Assert.Equal(4,player1.PlayerToRight.DrawPile.GetNumberOfCards());
        Assert.Equal(1,player1.PlayerToRight.DiscardPile.GetNumberOfCards());
        Assert.IsType<Artichoke>(player1.PlayerToRight.DiscardPile.GetCards()[0]);
    }
}