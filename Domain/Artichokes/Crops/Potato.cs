namespace Artichokes;

public class Potato : ICard
{
    public string CardDescription => "Reveals the top card of your draw pile. If this card is an Artichoke, it is removed. Otherwise it will be added to your discard pile.";

    public string CardName => "Potato";

    public bool MayBePlayed(Player player)
    {
        return player.DiscardPile.GetNumberOfCards() > 0 || player.DrawPile.GetNumberOfCards() > 0;
    }

    public String EncodeAsString()
    {
        return "p";
    }

    public void Play(Player player, string[] selectedOptions)
    {
        player.RefillDrawPileIfNeededAndPossible();
        if (player.DrawPile.GetNumberOfCards() > 0)
        {
            ICard card = player.DrawPile.GetTopCard();
            player.DrawPile.RemoveTopCard();
            if (card.GetType() != typeof(Artichoke))
            {
                player.DiscardPile.Add(card);
            }
        }
    }

    public string[] GetOptions(Player player)
    {
        return Array.Empty<string>();
    }
}