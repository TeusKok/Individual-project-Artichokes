namespace Artichokes;

public class Potato : ICard
{
    public string CardDescription => "Reveals the top card of your draw pile. " +
        "If this card is an Artichoke, it is removed. " +
        "Otherwise it will be added to your discard pile.";

    public string CardName => "Potato";

    public bool MayBePlayedBy(Player player)
    {
        return player.DiscardPile.GetNumberOfCards() + player.DrawPile.GetNumberOfCards() > 0;
    }

    public String EncodeAsString()
    {
        return "p";
    }

    public void Play(Player player, string selectedOption)
    {
        if (this.MayBePlayedBy(player))
        {
            player.RefillDrawPileIfNeededAndPossible();
            ICard topCard = player.DrawPile.GetTopCard();
            player.DrawPile.RemoveTopCard();
            if (topCard.GetType() != typeof(Artichoke))
            {
                player.DiscardPile.Add(topCard);
            }
        }
    }

    public string GetOption(Player player)
    {
        return string.Empty;
    }
}