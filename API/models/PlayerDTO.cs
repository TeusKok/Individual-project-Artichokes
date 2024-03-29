namespace DTO;
using Artichokes;

public class PlayerDTO
{
    public string Name { get; set; }
    public Boolean HasTurn { get; set; }
    public Boolean HarvestedCard { get; set; }
    public HandDTO Hand { get; set; }
    public DrawPileDTO DrawPile { get; set; }
    public DiscardPileDTO DiscardPile { get; set; }
    public PlayerDTO(string name, Player player)
    {
        Name = name;
        HasTurn = player.IsActivePlayer;
        HarvestedCard = player.HarvestedCard;
        Hand = new HandDTO(player);
        DrawPile = new DrawPileDTO { NumberOfCards = player.DrawPile.GetNumberOfCards() };
        DiscardPile = new DiscardPileDTO(player.DiscardPile);

    }
}