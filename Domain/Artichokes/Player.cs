

namespace Artichokes;

public class Player
{
    public GardenSupply SharedGardenSupply { get; private set; }

    public List<ICard> Hand { get; private set; } = new List<ICard>();
    public DrawPile DrawPile { get; private set; } = null!;
    public DiscardPile DiscardPile { get; private set; } = null!;
    public Player PlayerToRight { get; private set; }

    public Boolean IsActivePlayer { get; private set; }

    public Boolean HarvestedCard { get; private set; }
    public Boolean PlayedCard { get; private set; }

    public string Name { get; private set; } = null!;

    private Random rng = new Random();

    public Player() : this(new string[4] { "Piet", "Joop", "Jan", "Jaap" })
    {

    }

    public Player(string[] playerNames)
    {
        if (playerNames.Length < 2 || playerNames.Length > 4)
        {
            throw new InvalidOperationException("invalid number of Players, must be 2,3 or 4");
        }
        SharedGardenSupply = new GardenSupply();
        this.IsActivePlayer = true;
        InitializeDrawAndDiscardPilesAndSetName(playerNames[0]);
        this.PlayerToRight = new Player(this, SharedGardenSupply, playerNames[1..4]);
    }

    private Player(Player firstPlayer, GardenSupply gardenSupply, string[] playerNames)
    {
        SharedGardenSupply = gardenSupply;
        this.IsActivePlayer = true;
        InitializeDrawAndDiscardPilesAndSetName(playerNames[0]);
        this.IsActivePlayer = false;
        int numberOfPlayersLeft = playerNames.Length;
        if (numberOfPlayersLeft > 1)
        {
            this.PlayerToRight = new Player(firstPlayer, gardenSupply, playerNames[1..numberOfPlayersLeft]);
        }
        else
        {
            this.PlayerToRight = firstPlayer;
        }
    }

    private void InitializeDrawAndDiscardPilesAndSetName(string playerName)
    {
        this.DrawPile = new DrawPile();
        this.DiscardPile = new DiscardPile();
        this.Name = playerName;
        FillHand();
    }

    public Player(string gameStateString)
    {
        string[] players = gameStateString.Split("|")[0..4];
        string[] playerOneStrings = players[0].Split("/");

        this.SharedGardenSupply = new GardenSupply(gameStateString.Split("|")[4..6]);

        SetObjectVariablesBasedOnPlayerStrings(playerOneStrings);

        this.PlayerToRight = new Player(players[1..4], this.SharedGardenSupply, this);

    }



    private Player(string[] stringsOfPlayers, GardenSupply gardenSupply, Player firstPlayer)
    {
        int numberOfPlayersLeft = stringsOfPlayers.Length;
        this.SharedGardenSupply = gardenSupply;
        SetObjectVariablesBasedOnPlayerStrings(stringsOfPlayers[0].Split("/"));
        if (numberOfPlayersLeft > 1)
        {
            this.PlayerToRight = new Player(stringsOfPlayers[1..numberOfPlayersLeft], this.SharedGardenSupply, firstPlayer);
        }
        else
        {
            this.PlayerToRight = firstPlayer;
        }
    }

    private void SetObjectVariablesBasedOnPlayerStrings(string[] playerStrings)
    {
        this.Name = playerStrings[0];
        char[] handChars = playerStrings[1].ToCharArray();
        foreach (char character in handChars)
        {
            if (!character.Equals('0'))
            {
                Hand.Add(Utilities.CardFromCharacter(character));
            }
        }
        DrawPile = new DrawPile(playerStrings[2]);
        DiscardPile = new DiscardPile(playerStrings[3]);
        this.HarvestedCard = playerStrings[4].Equals("1");
        this.IsActivePlayer = playerStrings[5].Equals("1");
    }

    public Player GetWinner()
    {
        return GetWinner(this);
    }

    private Player GetWinner(Player player)
    {
        if (this.PlayerHasWon())
        {
            return this;
        }
        else
        {
            return PlayerToRight.GetWinnerIfPlayerToRightUnchecked(player);
        }
    }

    private bool PlayerHasWon()
    {
        return !Hand.OfType<Artichoke>().Any() && !this.IsActivePlayer;
    }

    private Player GetWinnerIfPlayerToRightUnchecked(Player player)
    {
        if (this != player)
        {
            return GetWinner(player);

        }
        else throw new InvalidOperationException("Game is not over, so winner could not be found");
    }

    public void FillHand()
    {
        if (this.IsActivePlayer)
        {
            int cardsInHandAfterRefill = Math.Min(5, DrawPile.GetNumberOfCards() + DiscardPile.GetNumberOfCards() + this.Hand.Count);
            while (Hand.Count < cardsInHandAfterRefill)
            {
                RefillDrawPileIfNeededAndPossible();
                Hand.Add(DrawPile.GetTopCard());
                DrawPile.RemoveTopCard();
            }
        }
    }

    public void DiscardHand()
    {
        if (this.IsActivePlayer)
        {
            foreach (ICard card in Hand)
            {
                DiscardPile.Add(card);
            }
            Hand.Clear();
        }

    }

    public void EndTurn()
    {
        if (this.IsActivePlayer)
        {
            this.DiscardHand();
            this.FillHand();
            this.SharedGardenSupply.RefillGardenSupply();
            this.HarvestedCard = false;
            this.PlayedCard = false;
            IsActivePlayer = false;
            PlayerToRight.IsActivePlayer = true;
        }
    }

    public void PlayCardFromHandByNumber(int numberOfCard, string selectedOption)
    {
        if (numberOfCard > 0 && numberOfCard <= Hand.Count && this.IsActivePlayer)
        {
            ICard card = Hand[numberOfCard - 1];
            if (card.MayBePlayedBy(this))
            {
                card.Play(this, selectedOption);
                MoveCardToDiscardPileIfStillInHand(card);
                this.PlayedCard = true;
            }

        }
    }

    public void MoveCardToDiscardPileIfStillInHand(ICard card)
    {
        if (Hand.Contains(card))
        {
            DiscardPile.Add(card);
            Hand.Remove(card);
        }
    }

    public void RefillDrawPileIfNeededAndPossible()
    {
        if (this.DrawPile.GetNumberOfCards() == 0 && this.DiscardPile.GetNumberOfCards() > 0)
        {
            DiscardPile.Shuffle();
            DiscardPile.Shuffle();
            this.DrawPile.AddToPile(this.DiscardPile.GetCards());
            this.DiscardPile.EmptyDiscardPile();
        }
    }

    public void HarvestCardFromGardenSupply(int numberOfCard)
    {
        if (numberOfCard > 0 && numberOfCard <= 5 && !this.HarvestedCard && this.IsActivePlayer)
        {
            Hand.Add(SharedGardenSupply.GetCardByNumber(numberOfCard));
            SharedGardenSupply.RemoveCardByNumber(numberOfCard);
            this.HarvestedCard = true;
        }

    }

    public Player GetPlayerByName(string name)
    {
        return this.GetPlayerByName(name, this);
    }
    private Player GetPlayerByName(string name, Player player)
    {
        if (this.Name.Equals(name))
        {
            return this;
        }

        if (this.PlayerToRight.Equals(player))
        {
            throw new InvalidOperationException("No player was found with the given name");
        }
        
        return this.PlayerToRight.GetPlayerByName(name, player);
    }

    public void SetHarvestedCardToFalse()
    {
        this.HarvestedCard = false;
    }

    public void MakeAllPlayersGiveTwoCardsToTheLeft()
    {
        int numberOfCards = Math.Min(Hand.Count, 2);

        List<ICard> cardsToSend = Hand.OrderBy(x => rng.Next()).Take(numberOfCards).ToList();
        this.Hand.RemoveAll(card => cardsToSend.Contains(card));

        this.PlayerToRight.PlayerToRight.PlayerToRight.GiveTwoCardsToTheLeft(cardsToSend, 1);
    }
    public void GiveTwoCardsToTheLeft(List<ICard> cards, int counter)
    {
        int numberOfCards = Math.Min(Hand.Count, 2);


        if (counter < 4)
        {
            List<ICard> cardsToSend = Hand.OrderBy(x => rng.Next()).Take(numberOfCards).ToList();
            this.Hand.RemoveAll(card => cardsToSend.Contains(card));
            this.PlayerToRight.PlayerToRight.PlayerToRight.GiveTwoCardsToTheLeft(cardsToSend, counter + 1);
        }
        Hand.AddRange(cards);
    }

    /// <summary>
    /// Encodes playerState as string
    /// </summary>
    /// <returns>String in format: name/CardsInHand/DrawPile/DiscardPile/hasHarvested/isPlayerActive</returns>
    public string EncodeAsString()
    {
        string s = Name + "/";
        if (Hand.Count > 0)
        {
            foreach (ICard card in Hand)
            {
                s += card.EncodeAsString();
            }
        }
        else
        {
            s += "0";
        }
        s = $"{s}/{DrawPile.EncodeAsString()}/{DiscardPile.EncodeAsString()}";
        string hasHarvested = HarvestedCard ? "1" : "0";
        string playerIsActive = IsActivePlayer ? "1" : "0";
        s = $"{s}/{hasHarvested}/{playerIsActive}";
        return s;
    }


}

