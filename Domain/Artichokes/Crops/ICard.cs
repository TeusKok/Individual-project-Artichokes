using System;
using System.Runtime.CompilerServices;

namespace Artichokes;
class InvalidCardPlayedException : System.Exception
{
    public InvalidCardPlayedException(string message) : base(message) { }
}
public interface ICard
{

    void Play(Player player, string selectedOption);

    String CardName { get; }

    String CardDescription { get; }

    Boolean MayBePlayedBy(Player player);

    String EncodeAsString();

    String GetOption(Player player);




}
