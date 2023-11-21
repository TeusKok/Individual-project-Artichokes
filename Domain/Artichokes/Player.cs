using System.Data;

namespace Artichokes;

public class Player{
    public GardenSupply SharedGardenSupply {get; private set;}

    public List<ICard> Hand {get; private set;} = new List<ICard>();
    public DrawPile DrawPile {get; private set;} = new DrawPile();
    public DiscardPile DiscardPile {get; private set;} = new DiscardPile();
    public Player PlayerToRight {get; private set;}
    
    public Player() : this(4){}

    public Player(int numberOfPlayers){
        if(numberOfPlayers<2||numberOfPlayers>4){
            throw new InvalidOperationException("invalid number of Players, must be 2,3 or 4");
        }

        SharedGardenSupply = new GardenSupply();
        FillHand();
        this.PlayerToRight = new Player(this,2,numberOfPlayers,SharedGardenSupply);
        
    }

    private Player(Player firstPlayer, int count, int numberOfPlayers, GardenSupply gardenSupply){
        SharedGardenSupply = gardenSupply;
        FillHand();
        if(count<numberOfPlayers){
            this.PlayerToRight = new Player(firstPlayer,count+1,numberOfPlayers,gardenSupply);
        }
        else{
            this.PlayerToRight = firstPlayer;
        }
    }

    public void FillHand()
    {
        while(Hand.Count<5){
            if (DrawPile.NumberOfCards() == 0){
                if(DiscardPile.NumberOfCards()!=0){
                    DrawPile.AddToPile(DiscardPile.EmptyDiscardPile());
                }
                else{
                    break;
                }
            }
            Hand.Add(DrawPile.Draw());
        }
    }

    public void DiscardHand(){
        foreach (ICard card in Hand)
        {
            DiscardPile.Add(card);
        }
        Hand.Clear();
        
    }


}

