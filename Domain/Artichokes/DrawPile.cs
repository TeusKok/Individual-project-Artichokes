using System.ComponentModel.DataAnnotations;

namespace Artichokes;

public class DrawPile {
    private readonly List<ICard> Cards = new List<ICard>();

    public int NumberOfCards(){
        return Cards.Count;
    }

    public DrawPile(){
        for(int i =0; i<10; i++){
            Cards.Add(new Artichoke());
        }
    }

    
    public ICard GetTopCard(){
        return Cards[0];
    }

    public void RemoveTopCard(){
        Cards.RemoveAt(0);
    }

    public void AddToPile(List<ICard> cards){
        Cards.AddRange(cards);
    }

    
} 
