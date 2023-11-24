using System.Data;

namespace Artichokes;

public class Player
{
    public GardenSupply SharedGardenSupply { get; private set; }

    public List<ICard> Hand { get; private set; } = new List<ICard>();
    public DrawPile DrawPile { get; private set; } = new DrawPile();
    public DiscardPile DiscardPile { get; private set; } = new DiscardPile();
    public Player PlayerToRight { get; private set; }

    public Boolean isActivePlayer { get; private set; }

    public Boolean HarvestedCard { get; private set; }

    public Player() : this(4) { }

    public Player(int numberOfPlayers)
    {
        if (numberOfPlayers < 2 || numberOfPlayers > 4)
        {
            throw new InvalidOperationException("invalid number of Players, must be 2,3 or 4");
        }
        this.isActivePlayer = true;
        SharedGardenSupply = new GardenSupply();
        FillHand();
        this.PlayerToRight = new Player(this, 2, numberOfPlayers, SharedGardenSupply);

    }

    private Player(Player firstPlayer, int count, int numberOfPlayers, GardenSupply gardenSupply)
    {
        SharedGardenSupply = gardenSupply;
        this.isActivePlayer = true;
        FillHand();
        this.isActivePlayer = false;
        if (count < numberOfPlayers)
        {
            this.PlayerToRight = new Player(firstPlayer, count + 1, numberOfPlayers, gardenSupply);
        }
        else
        {
            this.PlayerToRight = firstPlayer;
        }
    }

    public void FillHand()
    {
        if (isActivePlayer)
        {
            while (Hand.Count < 5)
            {
                if (DrawPile.NumberOfCards() == 0)
                {
                    if (DiscardPile.NumberOfCards() != 0)
                    {
                        DrawPile.AddToPile(DiscardPile.EmptyDiscardPile());
                    }
                    else
                    {
                        break;
                    }
                }
                Hand.Add(DrawPile.GetTopCard());
                DrawPile.RemoveTopCard();
            }
        }
    }

    public void DiscardHand()
    {
        if (isActivePlayer)
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
        if (isActivePlayer)
        {
            this.HarvestedCard = false;
            this.DiscardHand();
            this.FillHand();
            this.SharedGardenSupply.refillGardenSupply(); 
            isActivePlayer = !isActivePlayer;
            PlayerToRight.isActivePlayer = !PlayerToRight.isActivePlayer;
        }
    }

    public void PlayCardFromHandByNumber(int numberOfCard)
    {
        if (numberOfCard > 0 && numberOfCard <= Hand.Count && isActivePlayer)
        {
            ICard card = Hand[numberOfCard - 1];
            if (card.MayBePlayed(this))
            {
                card.Play(this);
                if (Hand.Contains(card))
                {
                    DiscardPile.Add(card);
                    Hand.Remove(card);
                }
            }

        }
    }

    public void RefillDrawPileIfNeededAndPossible()
    {
        if (this.DrawPile.NumberOfCards() == 0 && this.DiscardPile.NumberOfCards() > 0)
        {
            this.DrawPile.AddToPile(this.DiscardPile.getCards());
            this.DiscardPile.EmptyDiscardPile();
        }
    }

    public void HarvestCardFromGardenSupply(int numberOfCard)
    {
        if (numberOfCard > 0 && numberOfCard <= 5 && !this.HarvestedCard && this.isActivePlayer)
        {
            Hand.Add(SharedGardenSupply.GetCardByNumber(numberOfCard));
            SharedGardenSupply.RemoveCardByNumber(numberOfCard);
            this.HarvestedCard = true;
        }

    }


}

