namespace Artichokes;

public interface IArtichokeGame
{
    public enum Winner
    {
        PlayerOne,
        PlayerTwo,
        PlayerThree,
        PlayerFour,
        NoOneYet,

    }
    // players are numbered like this  1  2
    //                                 4  3  

    String getNameOfPlayer(int numberOfPlayer);

    int getNumberOfCardsInHand(int numberOfPlayer);

    void discardHand(int numberOfPlayer);

    void refillHand(int numberOfPlayer);

    public String getNameFromCardFromHand(int numberOfPlayer, int numberOfCard);

    public String getDescriptionFromCardFromHand(int numberOfPlayer, int numberOfCard);

    public int getNumberOfCardsInDrawPile(int numberOfPlayer);

    public int getNumberOfCardsInDiscardPile(int numberOfPlayer);

    public Player getPlayerByNumber(int numberOfPlayer);

    public int getPlayerNumberByName(string name);
    void endTurnOfPlayer(int numberOfPlayer);
    public void playCardFromHand(int numberOfPlayer, int numberOfCard, string[] selectedOptions);

    public Player getActivePlayer();
    public Winner GetWinner();

    public string AsString();

}