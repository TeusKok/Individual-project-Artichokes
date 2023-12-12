namespace DTO;
using Artichokes;

public class HandDTO
{
    public CardDTO[] Cards { get; }

    public HandDTO(Player player)
    {

        Cards = new CardDTO[player.Hand.Count];
        for (int i = 0; i < player.Hand.Count; i++)
        {
            string[] optionStrings = player.Hand[i].GetOptions(player);
            OptionDTO[] optionArray = new OptionDTO[optionStrings.Length];
            for (int j = 0; j < optionStrings.Length; j++)
            {
                optionArray[j] = new OptionDTO
                {
                    Question = optionStrings[j].Split("|")[0],
                    Answers = optionStrings[j].Split("|")[1].Split("/")
                };
            }

            Cards[i] = new CardDTO
            {
                CardName = player.Hand[i].CardName,
                CardDescription = player.Hand[i].CardDescription,
                MayBePlayed = player.Hand[i].MayBePlayed(player),
                Options = optionArray,
            };
        }

    }
}