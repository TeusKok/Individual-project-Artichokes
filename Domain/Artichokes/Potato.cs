namespace Artichokes;

public class Potato : ICard
{
    public string getCardDescription()
    {
        return "Reveals the top card of your draw pile. If this card is an Artichoke, it is removed. Otherwise it will be added to your discard pile.";
    }

    public string getCardName()
    {
        return "Potato";
    }

    public void Play(Player player)
    {
        ICard card = player.DrawPile.GetTopCard();
        player.DrawPile.RemoveTopCard();
        if(card.GetType() != typeof(Artichoke)){
            player.DiscardPile.Add(card);
        }
        player.DiscardPile.Add(this);
    }
}