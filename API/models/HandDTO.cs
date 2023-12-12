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
            string optionString = player.Hand[i].GetOption(player);
            OptionDTO option;
            if (optionString.Length > 0)
            {
                option = new OptionDTO
                {
                    Question = optionString.Split("|")[0],
                    Answers = optionString.Split("|")[1].Split("/")
                };
            }
            else
            {
                option = new OptionDTO
                {
                    Question = "",
                    Answers = Array.Empty<string>(),
                };
            }

            Cards[i] = new CardDTO
            {
                CardName = player.Hand[i].CardName,
                CardDescription = player.Hand[i].CardDescription,
                MayBePlayed = player.Hand[i].MayBePlayedBy(player),
                Option = option,
            };
        }

    }
}