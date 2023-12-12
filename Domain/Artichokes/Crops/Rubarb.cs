namespace Artichokes;
public class Rubarb : ICard
{
    public string EncodeAsString()
    {
        return "r";
    }

    public string CardDescription => "refreshes the Garden Supply, you may then harvest a card from the new Supply";

    public string CardName => "Rubarb";

    public string[] GetOptions(Player player)
    {
        return Array.Empty<string>();
    }

    public bool MayBePlayed(Player player)
    {
        return true;
    }

    public void Play(Player player, string[] selectedOptions)
    {
        while (player.SharedGardenSupply.GetNumberOfCards() > 0)
        {
            player.SharedGardenSupply.RemoveCardByNumber(player.SharedGardenSupply.GetNumberOfCards());
        }

        player.SharedGardenSupply.refillGardenSupply();
        player.SetHarvestedCardToFalse();
    }
}