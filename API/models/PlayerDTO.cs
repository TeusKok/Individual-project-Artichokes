using Artichokes;

public class PlayerDTO{
    public string Name {get; set;}
    public HandDTO Hand {get; set;}
    public DrawPileDTO DrawPile {get; set;}
    public DiscardPileDTO DiscardPile {get; set;}
    public PlayerDTO(string name, Player player){
        Name = name;
        Hand = new HandDTO(player.hand);
        DrawPile = new DrawPileDTO{NumberOfCards = player.drawPile.NumberOfCards()};
        DiscardPile = new DiscardPileDTO(player.discardPile);

    }
}