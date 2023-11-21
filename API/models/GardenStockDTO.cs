namespace DTO;
using Artichokes;
public class GardenStockDTO
{
    public int NumberOfCards {set;get;}

    public GardenStockDTO(GardenStock gardenStock){
        this.NumberOfCards = gardenStock.GetNumberOfCards();
    }
}