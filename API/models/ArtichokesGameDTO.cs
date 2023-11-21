using Artichokes;

public class ArtichokeGameDTO{
    public PlayerDTO[] Players {get; set;} = new PlayerDTO[4];
    public ArtichokeGameDTO(IArtichokeGame game){
        for (int i = 0; i < 4; i++)
        {
            Players[i] = new PlayerDTO(game.getNameOfPlayer(i+1),game.getPlayerByNumber(i+1));
        }
        

    }
}