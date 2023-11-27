using Artichokes;
namespace DTO;

public class ArtichokeGameDTO
{
    public PlayerDTO[] Players { get; set; } = new PlayerDTO[4];
    public GardenStockDTO GardenStock { get; set; }
    public GardenSupplyDTO GardenSupply { get; set; }

    public GameStatusDTO GameStatus { get; set; }

    public ArtichokeGameDTO(IArtichokeGame game)
    {
        for (int i = 0; i < 4; i++)
        {
            Players[i] = new PlayerDTO(game.getNameOfPlayer(i + 1), game.getPlayerByNumber(i + 1));
        }
        GardenStock = new GardenStockDTO(game.getPlayerByNumber(1).SharedGardenSupply.gardenStock);
        Boolean activePlayerHasHarvested = game.getActivePlayer().HarvestedCard;
        GardenSupply = new GardenSupplyDTO(game.getPlayerByNumber(1).SharedGardenSupply, !activePlayerHasHarvested);
        GameStatus = new GameStatusDTO(game);


    }


}

