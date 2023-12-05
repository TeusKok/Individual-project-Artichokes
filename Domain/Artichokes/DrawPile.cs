using System.ComponentModel.DataAnnotations;

namespace Artichokes;

public class DrawPile
{
    private List<ICard> Cards = new List<ICard>();

    public int GetNumberOfCards()
    {
        return Cards.Count;
    }

    public DrawPile()
    {
        for (int i = 0; i < 10; i++)
        {
            Cards.Add(new Artichoke());
        }
    }

    public DrawPile(string drawPileString)
    {
        char[] cardChars = drawPileString.ToCharArray();
        foreach (char cardChar in cardChars)
        {
            if (!cardChar.Equals('0'))
            {
                this.Cards.Add(Utilities.CardFromCharacter(cardChar));
            }
        }
    }


    public ICard GetTopCard()
    {
        return Cards[0];
    }

    public void RemoveTopCard()
    {
        Cards.RemoveAt(0);
    }

    public void AddToPile(List<ICard> cards)
    {
        Cards.AddRange(cards);
    }

    public void AddCardOnTop(ICard card)
    {
        Cards = Cards.Prepend(card).ToList<ICard>();
    }

    public string AsString()
    {
        string s = "";
        if (Cards.Count > 0)
        {
            foreach (ICard card in Cards)
            {
                s += card.AsString();
            }
        }
        else
        {
            s += "0";
        }
        return s;
    }


}
