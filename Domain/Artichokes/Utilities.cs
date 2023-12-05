namespace Artichokes;
public class Utilities
{
    public static ICard CardFromCharacter(char character)
    {

        return character switch
        {
            'a' => new Artichoke(),
            'c' => new Carrot(),
            'p' => new Potato(),
            'i' => new Broccoli(),
            'o' => new Onion(),
            't' => new Beet(),
            'r' => new Rubarb(),
            'C' => new Corn(),
            'B' => new Bellpepper(),
            'b' => new BroadBean(),
            'l' => new Leek(),
            'e' => new Eggplant(),

            _ => throw new InvalidOperationException(character + " is not a known character"),
        };
    }
}