namespace Artichokes;
public class Corn : ICard
{
    public string AsString()
    {
        return "C";
    }

    public string GetCardDescription()
    {
        return "This card is played together with an Artichoke,"
            + " both cards get placed on your discardPile. Then you may pick a card,"
            + " this card gets placed on the top of your Draw Pile";
    }

    public string GetCardName()
    {
        return "Corn";
    }

    public string[] GetOptions(Player player)
    {
        string s = "Pick One of these cards, it will be placed on top of your Draw Pile.|";
        for (int i = 0; i < player.SharedGardenSupply.GetNumberOfCards(); i++)
        {
            s = s + (i + 1) + ": " + player.SharedGardenSupply.GetCardByNumber(i + 1).GetCardName();
            if (i < player.SharedGardenSupply.GetNumberOfCards() - 1)
            {
                s += "/";
            }
        }
        return new string[] { s };
    }

    public bool MayBePlayed(Player player)
    {
        return player.Hand.OfType<Artichoke>().Any();
    }

    public void Play(Player player, string[] selectedOptions)
    {
        if (selectedOptions.Length == 1)
        {
            ICard artichoke = player.Hand.OfType<Artichoke>().First();
            player.Hand.Remove(artichoke);
            player.DiscardPile.Add(artichoke);
            Int32 selectedCardNumber = Int32.Parse(selectedOptions[0].Split(":")[0]);
            ICard selectedCard = player.SharedGardenSupply.GetCardByNumber(selectedCardNumber);

            player.DrawPile.AddCardOnTop(selectedCard);
            player.SharedGardenSupply.RemoveCardByNumber(selectedCardNumber);
        }



    }
}