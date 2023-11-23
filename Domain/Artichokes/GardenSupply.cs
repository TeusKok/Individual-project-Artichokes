namespace Artichokes;
public class GardenSupply{

    private List<ICard> Cards{ get; set;}
    public GardenStock gardenStock{ get; private set;} 

    public GardenSupply(){
        Cards = new List<ICard>();
        gardenStock = new GardenStock();
        refillGardenSupply();
        
    }

    //card number between 1 and 5
    public ICard GetCardByNumber(int cardNumber){
        if(cardNumber <=Cards.Count && cardNumber>0){
            return Cards[cardNumber-1];   
        }
        else throw new InvalidOperationException("not a valid card number pick a number from 1 to the number of cards in the GardenSupply");

    }

    public void RemoveCardByNumber(int cardNumber){
        if(cardNumber <=Cards.Count && cardNumber>0){
            Cards.RemoveAt(cardNumber-1);
        }
        else throw new InvalidOperationException("not a valid card number pick a number from 1 to the number of cards in the GardenSupply");
    }

    public void AddCard(ICard card){
        Cards.Add(card);
    }

    public int GetNumberOfCards(){
        return Cards.Count;
    }

    public void refillGardenSupply(){
        while(Cards.Count <5){
            if(gardenStock.GetNumberOfCards()<1){
                break;
            }
            Cards.Add(gardenStock.getTopCard());
            gardenStock.removeTopCard();
        }
    }

}