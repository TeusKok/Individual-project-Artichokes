namespace Artichokes;
public class Utilities
{
    public static ICard CardFromCharacter(char character)
    {

        return character switch
        {
            'a' => new Artichoke(),
            'c' => new Carrot(),
            'P' => new Potato(),
            'i' => new Broccoli(),
            'o' => new Onion(),
            't' => new Beet(),
            'r' => new Rubarb(),
            _ => throw new InvalidOperationException(character + " is not a known character"),
        };
    }
}