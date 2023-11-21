using Artichokes;
namespace Repositories;

public interface IRepository
{
    public void Save(string key, IArtichokeGame game);

    public IArtichokeGame Get(string key);
}