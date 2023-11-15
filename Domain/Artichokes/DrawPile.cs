using System.ComponentModel.DataAnnotations;

namespace Artichokes;

public class DrawPile : ICardCollection{
    private List<ICard> drawPile = new List<ICard>();

    public int NumberOfCards(){
        return drawPile.Count;
    }

    public DrawPile(){
        for(int i =0; i<10; i++){
            drawPile.Add(new Artichoke());
        }
    }

    public ICard Draw(){
        ICard card = drawPile[0];
        drawPile.RemoveAt(0);
        return card;
    }

    public void AddToPile(List<ICard> cards){
        drawPile.AddRange(cards);
    }

    public void shuffle()
    {
        throw new NotImplementedException();
    }
} 
