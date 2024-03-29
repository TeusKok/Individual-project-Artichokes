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
    public void playCardFromHand(int numberOfPlayer, int numberOfCard, string selectedOption);
    public void HarvestCardFromGardenSupply(int numberOfPlayer, int numberOfCard);

    public int getNumberOfActivePlayer();
    public Winner GetWinner();

    /// <summary>
    /// Encodes gamestate as string
    /// </summary>
    /// <returns>String in format: player1|player2|player3|player4|gardenstock|gardensupply</returns>
    public string EncodeAsString();

}