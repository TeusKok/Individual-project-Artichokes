namespace Artichokes;

public interface IArtichokeGame{
    // players are numbered like this  1  2
    //                                 3  4  

    String getNameOfPlayer(int numberOfPlayer);

    int getNumberOfCardsInHand(int numberOfPlayer);

    void discardHand(int numberOfPlayer);

    void refillHand(int numberOfPlayer);

    String getNameFromCardFromHand(int numberOfPlayer, int numberOfCard);
    
    String getDescriptionFromCardFromHand(int numberOfPlayer, int numberOfCard);

    int getNumberOfCardsInDrawPile(int numberOfPlayer);

    int getNumberOfCardsInDiscardPile(int numberOfPlayer);
}