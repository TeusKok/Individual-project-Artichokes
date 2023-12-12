namespace Artichokes;
public class Corn : ICard
{
    public string EncodeAsString()
    {
        return "C";
    }

    public string CardDescription => "This card is played together with an Artichoke,"
            + " both cards get placed on your discardPile. Then you may pick a card,"
            + " this card gets placed on the top of your Draw Pile";

    public string CardName => "Corn";

    public string GetOption(Player player)
    {
        string s = "Pick One of these cards, it will be placed on top of your Draw Pile.|";
        for (int i = 0; i < player.SharedGardenSupply.GetNumberOfCards(); i++)
        {
            s = $"{s}{i + 1}: {player.SharedGardenSupply.GetCardByNumber(i + 1).CardName}";
            if (i < player.SharedGardenSupply.GetNumberOfCards() - 1)
            {
                s += "/";
            }
        }
        return s;
    }

    public bool MayBePlayedBy(Player player)
    {
        return player.Hand.OfType<Artichoke>().Any();
    }

    public void Play(Player player, string selectedOption)
    {
        if (selectedOption.Length > 0)
        {
            ICard artichoke = player.Hand.OfType<Artichoke>().First();
            player.Hand.Remove(artichoke);
            player.DiscardPile.Add(artichoke);
            Int32 selectedCardNumber = Int32.Parse(selectedOption.Split(":")[0]);
            ICard selectedCard = player.SharedGardenSupply.GetCardByNumber(selectedCardNumber);

            player.DrawPile.AddCardOnTop(selectedCard);
            player.SharedGardenSupply.RemoveCardByNumber(selectedCardNumber);
        }



    }
}