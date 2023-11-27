namespace DTO;
using Artichokes;
public class GameStatusDTO
{
    public Boolean GameOver { get; set; }
    public String Winner { get; set; }

    public GameStatusDTO(IArtichokeGame game)
    {
        IArtichokeGame.Winner winner = game.GetWinner();
        if (winner != IArtichokeGame.Winner.NoOneYet)
        {
            this.GameOver = true;
            switch (winner)
            {
                case IArtichokeGame.Winner.PlayerOne: { Winner = game.getNameOfPlayer(1); break; }
                case IArtichokeGame.Winner.PlayerTwo: { Winner = game.getNameOfPlayer(2); break; }
                case IArtichokeGame.Winner.PlayerThree: { Winner = game.getNameOfPlayer(3); break; }
                default: { Winner = game.getNameOfPlayer(4); break; }
            }
        }
        else
        {
            GameOver = false;
            Winner = "";
        }
    }
}