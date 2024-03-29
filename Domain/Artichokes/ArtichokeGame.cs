namespace Artichokes;

public class ArtichokeGame : IArtichokeGame
{
    Player player1;

    public ArtichokeGame(string name1, string name2, string name3, string name4)
    {
        string[] playerNames = new string[4] { name1, name2, name3, name4 };

        player1 = new Player(playerNames);
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
        return getPlayerByNumber(numberOfPlayer).Hand[numberOfCard - 1].CardDescription;
    }

    public string getNameFromCardFromHand(int numberOfPlayer, int numberOfCard)
    {
        return getPlayerByNumber(numberOfPlayer).Hand[numberOfCard - 1].CardName;
    }

    public string getNameOfPlayer(int numberOfPlayer)
    {
        return getPlayerByNumber(numberOfPlayer).Name;
    }

    public int getNumberOfCardsInDiscardPile(int numberOfPlayer)
    {
        return getPlayerByNumber(numberOfPlayer).DiscardPile.GetNumberOfCards();
    }

    public int getNumberOfCardsInDrawPile(int numberOfPlayer)
    {
        return getPlayerByNumber(numberOfPlayer).DrawPile.GetNumberOfCards();
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
        Player player = player1;
        for (int i = 0; i < 4; i++)
        {
            if (player.Name.Equals(name)) return i + 1;
            player = player.PlayerToRight;

        }
        return 0;
    }

    public void endTurnOfPlayer(int numberOfPlayer)
    {
        getPlayerByNumber(numberOfPlayer).EndTurn();
    }

    public void playCardFromHand(int numberOfPlayer, int numberOfCard, string selectedOption)
    {
        Player player = getPlayerByNumber(numberOfPlayer);
        player.PlayCardFromHandByNumber(numberOfCard, selectedOption);
    }

    public void HarvestCardFromGardenSupply(int numberOfPlayer, int numberOfCard)
    {
        Player player = getPlayerByNumber(numberOfPlayer);
        player.HarvestCardFromGardenSupply(numberOfCard);
    }

    public int getNumberOfActivePlayer()
    {
        Player player1 = getPlayerByNumber(1);
        if (player1.IsActivePlayer) return 1;
        if (player1.PlayerToRight.IsActivePlayer) return 2;
        if (player1.PlayerToRight.PlayerToRight.IsActivePlayer) return 3;
        if (player1.PlayerToRight.PlayerToRight.PlayerToRight.IsActivePlayer) return 4;
        else throw new Exception("there is no active player");
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

    /// <summary>
    /// Encodes gamestate as string
    /// </summary>
    /// <returns>String in format: player1|player2|player3|player4|gardenstock|gardensupply</returns>
    public string EncodeAsString()
    {
        string s = "";
        for (int i = 0; i < 4; i++)
        {
            Player player = getPlayerByNumber(i + 1);
            s = $"{s}{player.EncodeAsString()}|";
        }
        GardenSupply gardenSupply = player1.SharedGardenSupply;
        s = $"{s}{gardenSupply.gardenStock.EncodeAsString()}|{gardenSupply.AsString()}";

        return s;
    }
}