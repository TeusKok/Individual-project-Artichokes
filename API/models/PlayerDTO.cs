namespace DTO;
using Artichokes;

public class PlayerDTO{
    public string Name {get; set;}
    public HandDTO Hand {get; set;}
    public DrawPileDTO DrawPile {get; set;}
    public DiscardPileDTO DiscardPile {get; set;}
    public PlayerDTO(string name, Player player){
        Name = name;
        Hand = new HandDTO(player.Hand);
        DrawPile = new DrawPileDTO{NumberOfCards = player.DrawPile.NumberOfCards()};
        DiscardPile = new DiscardPileDTO(player.DiscardPile);

    }
}