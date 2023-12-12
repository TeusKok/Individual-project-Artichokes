namespace Artichokes;
public class Bellpepper : ICard
{
    public string EncodeAsString()
    {
        return "B";
    }

    public string CardDescription => "Choose a card from the cards in your Discard pile, " 
        + "this card is moved to the top of your Draw pile";

    public string CardName => "Bellpepper";

    public string GetOption(Player player)
    {
        string s = "Pick One of these cards, it will be placed on top of your Draw Pile.|";
        for (int i = 0; i < player.DiscardPile.GetNumberOfCards(); i++)
        {
            s = $"{s}{i + 1}: {player.DiscardPile.GetCards()[i].CardName}/"; 
        }
        if (s.Last().Equals('/')) s = s.Remove(s.Length - 1, 1);
        return s;
    }

    public bool MayBePlayedBy(Player player)
    {
        return player.DiscardPile.GetNumberOfCards() > 0;
    }

    public void Play(Player player, string selectedOption)
    {
        if (MayBePlayedBy(player) && selectedOption.Length > 0)
        {
            Int32 selectedCardNumber = Int32.Parse(selectedOption.Split(":")[0]);
            ICard selectedCard = player.DiscardPile.GetCards()[selectedCardNumber - 1];

            player.DrawPile.AddCardOnTop(selectedCard);
            player.DiscardPile.GetCards().Remove(selectedCard);
        }
    }
}