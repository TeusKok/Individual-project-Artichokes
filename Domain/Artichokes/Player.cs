using System.Data;

namespace Artichokes;

public class Player{
    public List<ICard> hand {get; private set;} = new List<ICard>();
    public DrawPile drawPile {get; private set;} = new DrawPile();
    public DiscardPile discardPile {get; private set;} = new DiscardPile();
    public Player playerToRight {get; private set;}
    
    public Player() : this(4){}

    public Player(int numberOfPlayers){
        if(numberOfPlayers<2||numberOfPlayers>4){
            throw new InvalidOperationException("invalid number of Players, must be 2,3 or 4");
        }
        
        FillHand();
        this.playerToRight = new Player(this,2,numberOfPlayers);
        
    }

    private Player(Player firstPlayer, int count, int numberOfPlayers){
        
        FillHand();
        if(count<numberOfPlayers){
            this.playerToRight = new Player(firstPlayer,count+1,numberOfPlayers);
        }
        else{
            this.playerToRight = firstPlayer;
        }
    }

    public void FillHand()
    {
        while(hand.Count<5){
            if (drawPile.NumberOfCards() == 0){
                if(discardPile.NumberOfCards()!=0){
                    drawPile.AddToPile(discardPile.EmptyDiscardPile());
                }
                else{
                    break;
                }
            }
            hand.Add(drawPile.Draw());
        }
    }

    public void DiscardHand(){
        foreach (ICard card in hand)
        {
            discardPile.Add(card);
        }
        hand.Clear();
        
    }


}

