namespace DTO;
public class CardDTO
{
    public required String CardName {get; set;}
    public required String CardDescription {get; set;}
    public required Boolean MayBePlayed {get; set;}
    public required OptionDTO Option {get; set;}

    
}