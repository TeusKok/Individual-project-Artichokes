namespace Artichokes;

public class ArtichokeGame : IArtichokeGame
{
    Player player1;

    public ArtichokeGame(string name1, string name2, string name3, string name4)
    {
        string[] playerNames = new string[4]{name1,name2,name3,name4};
        
        player1 = new Player(4,playerNames);
    }

    public ArtichokeGame(string gameStateString)
    {
        string[] players = gameStateString.Split("|")[0..4];

        this.player1 = new Player(gameStateString);
    }


    public void discardHand(int numberOfPlayer)
    {
        getPlayerByNumber(numberOfPlayer).DiscardHand();
    }

    public string getDescriptionFromCardFromHand(int numberOfPlayer, int numberOfCard)
    {
        return getPlayerByNumber(numberOfPlayer).Hand[numberOfCard - 1].GetCardDescription();
    }

    public string getNameFromCardFromHand(int numberOfPlayer, int numberOfCard)
    {
        return getPlayerByNumber(numberOfPlayer).Hand[numberOfCard - 1].GetCardName();
    }

    public string getNameOfPlayer(int numberOfPlayer)
    {
        return getPlayerByNumber(numberOfPlayer).Name;
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

    public Player getPlayerByNumber(int numberOfPlayer)
    {
        switch (numberOfPlayer)
        {
            case 1: return player1;
            case 2: return player1.PlayerToRight;
            case 3: return player1.PlayerToRight.PlayerToRight;
            case 4: return player1.PlayerToRight.PlayerToRight.PlayerToRight;
            default: throw new InvalidOperationException(numberOfPlayer + "invalid player number, pick 1, 2, 3, or 4");
        }
    }

    public int getPlayerNumberByName(string name)
    {
        Player player =player1;
        for (int i = 0; i < 4; i++)
        {
            if (player.Name.Equals(name)) return i + 1;
            player=player.PlayerToRight;
            
        }
        return 0;
    }

    public void endTurn(int numberOfPlayer)
    {
        getPlayerByNumber(numberOfPlayer).EndTurn();
    }

    public void playCardFromHand(int numberOfPlayer, int numberOfCard, string[] selectedOptions)
    {
        Player player = getPlayerByNumber(numberOfPlayer);
        player.PlayCardFromHandByNumber(numberOfCard, selectedOptions);
    }

    public void HarvestCardFromGardenSupply(int numberOfPlayer, int numberOfCard)
    {
        Player player = getPlayerByNumber(numberOfPlayer);
        player.HarvestCardFromGardenSupply(numberOfCard);
    }

    public Player getActivePlayer()
    {
        Player player = getPlayerByNumber(1);
        while (!player.IsActivePlayer)
        {
            player = player.PlayerToRight;
            if (player == getPlayerByNumber(1))
            {
                throw new Exception("There is no active player");
            }
        }
        return player;
    }

    public IArtichokeGame.Winner GetWinner()
    {
        try
        {
            Player winner = player1.GetWinner();
            if (winner == player1)
            {
                return IArtichokeGame.Winner.PlayerOne;
            }
            else if (winner == player1.PlayerToRight)
            {
                return IArtichokeGame.Winner.PlayerTwo;
            }
            else if (winner == player1.PlayerToRight.PlayerToRight)
            {
                return IArtichokeGame.Winner.PlayerThree;
            }
            else if (winner == player1.PlayerToRight.PlayerToRight.PlayerToRight)
            {
                return IArtichokeGame.Winner.PlayerFour;
            }
            else return IArtichokeGame.Winner.NoOneYet;
        }
        catch (System.Exception)
        {
            return IArtichokeGame.Winner.NoOneYet;
        }

    }

    public string AsString()
    {
        string s = "";
        for (int i = 0; i < 4; i++)
        {
            Player player = getPlayerByNumber(i + 1);
            s = s + player.AsString() + "|";
        }
        GardenSupply gardenSupply = player1.SharedGardenSupply;
        s = s + gardenSupply.gardenStock.AsString() + "|" + gardenSupply.AsString();

        return s;
    }
}