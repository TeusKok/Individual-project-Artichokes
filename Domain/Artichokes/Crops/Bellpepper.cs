namespace Artichokes;
public class Bellpepper : ICard
{
    public string AsString()
    {
        return "B";
    }

    public string GetCardDescription()
    {
        return "Choose a card from the cards in your Discard pile, this card is moved to the top of your Draw pile";
    }

    public string GetCardName()
    {
        return "Bellpepper";
    }

    public string[] GetOptions(Player player)
    {
        string s = "Pick One of these cards, it will be placed on top of your Draw Pile.|";
        for (int i = 0; i < player.DiscardPile.GetNumberOfCards(); i++)
        {
            s = s + (i + 1) + ": " + player.DiscardPile.GetCards()[i].GetCardName();
            if (i < player.DiscardPile.GetNumberOfCards() - 1)
            {
                s += "/";
            }
        }
        return new string[] { s };
    }

    public bool MayBePlayed(Player player)
    {
        return player.DiscardPile.GetNumberOfCards() > 0;
    }

    public void Play(Player player, string[] selectedOptions)
    {
        if (MayBePlayed(player) && selectedOptions.Length == 1)
        {
            Int32 selectedCardNumber = Int32.Parse(selectedOptions[0].Split(":")[0]);
            ICard selectedCard = player.DiscardPile.GetCards()[selectedCardNumber - 1];

            player.DrawPile.AddCardOnTop(selectedCard);
            player.DiscardPile.GetCards().Remove(selectedCard);
        }
    }
}