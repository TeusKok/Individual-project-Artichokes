namespace Artichokes;

public class Potato : ICard
{
    public string GetCardDescription()
    {
        return "Reveals the top card of your draw pile. If this card is an Artichoke, it is removed. Otherwise it will be added to your discard pile.";
    }

    public string GetCardName()
    {
        return "Potato";
    }

    public bool MayBePlayed(Player player)
    {
        return player.DiscardPile.NumberOfCards()>0||player.DrawPile.NumberOfCards()>0;
    }

    public void Play(Player player)
    {
        player.RefillDrawPileIfNeededAndPossible();
        if(player.DrawPile.NumberOfCards()>0){
            ICard card = player.DrawPile.GetTopCard();
            player.DrawPile.RemoveTopCard();
            if(card.GetType() != typeof(Artichoke)){
                player.DiscardPile.Add(card);
            }
        }
    }
}