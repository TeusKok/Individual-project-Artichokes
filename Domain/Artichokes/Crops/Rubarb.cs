namespace Artichokes;
public class Rubarb : ICard
{
    public string EncodeAsString()
    {
        return "r";
    }

    public string CardDescription => "refreshes the Garden Supply, " +
        "you may then harvest a card from the new Supply";

    public string CardName => "Rubarb";

    public string GetOption(Player player)
    {
        return string.Empty;
    }

    public bool MayBePlayedBy(Player player)
    {
        return true;
    }

    public void Play(Player player, string selectedOption)
    {
        while (player.SharedGardenSupply.GetNumberOfCards() > 0)
        {
            player.SharedGardenSupply.RemoveCardByNumber(1);
        }
        player.SharedGardenSupply.refillGardenSupply();
        player.SetHarvestedCardToFalse();
    }
}