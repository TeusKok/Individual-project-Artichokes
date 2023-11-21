namespace Artichokes;

public class ArtichokeGame : IArtichokeGame
{
    Player player1;
    String[] playerNames  = new string[4];

    public ArtichokeGame(string name1, string name2, string name3, string name4){
        playerNames[0] = name1;
        playerNames[1] = name2;
        playerNames[2] = name3;
        playerNames[3] = name4;
        player1 = new Player(4);
    }

    public void discardHand(int numberOfPlayer)
    {
        getPlayerByNumber(numberOfPlayer).DiscardHand();
    }

    public string getDescriptionFromCardFromHand(int numberOfPlayer, int numberOfCard)
    {
        return getPlayerByNumber(numberOfPlayer).Hand[numberOfCard-1].getCardDescription();
    }

    public string getNameFromCardFromHand(int numberOfPlayer, int numberOfCard)
    {
        return getPlayerByNumber(numberOfPlayer).Hand[numberOfCard-1].getCardName();
    }

    public string getNameOfPlayer(int numberOfPlayer)
    {
        return playerNames[numberOfPlayer-1];
    }

    public int getNumberOfCardsInDiscardPile(int numberOfPlayer)
    {
        return getPlayerByNumber(numberOfPlayer).DiscardPile.NumberOfCards();
    }

    public int getNumberOfCardsInDrawPile(int numberOfPlayer)
    {
        return getPlayerByNumber(numberOfPlayer).DrawPile.NumberOfCards();
    }

    public int getNumberOfCardsInHand(int numberOfPlayer)
    {
        return getPlayerByNumber(numberOfPlayer).Hand.Count;
    }

    public void refillHand(int numberOfPlayer)
    {
        getPlayerByNumber(numberOfPlayer).FillHand();
    }

    public Player getPlayerByNumber(int numberOfPlayer){
        switch (numberOfPlayer)
        {
            case 1: return player1;
            case 2: return player1.PlayerToRight;
            case 3: return player1.PlayerToRight.PlayerToRight;
            case 4: return player1.PlayerToRight.PlayerToRight.PlayerToRight;
            default: throw new InvalidOperationException("invalid player number, pick 1, 2, 3, or 4");
        }
    }

    public int getPlayerNumberByName(string name){
        for (int i = 0; i < 4; i++)
        {
            if(playerNames[i].Equals(name) ) return i+1;
        }
        return 0;
    }

    public void endTurn(int numberOfPlayer)
    {
        getPlayerByNumber(numberOfPlayer).EndTurn();
    }

    public void playCardFromHand(int numberOfPlayer, int numberOfCard)
    {
        Player player = getPlayerByNumber(numberOfPlayer);
        player.PlayCardFromHandByNumber(numberOfCard);
    }
}