using Artichokes;
namespace Repositories;

public interface IRepository
{
    public void Save(string key, string artichokeGameString);

    public IArtichokeGame Get(string key);

    public Boolean ContainsKey(string key);
}