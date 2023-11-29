using Artichokes;
namespace Repositories;
using MongoDB.Driver;
using MongoDB.Bson;
using Amazon.SecurityToken.Model;

public class Repository : IRepository
{
    // Connection URI
    const string connectionUri = "mongodb+srv://MainMan:VuurBanaan123@cluster0.5zmjls6.mongodb.net/?retryWrites=true&w=majority";
    // Create a new client and connect to the server
    MongoClient client = new MongoClient(connectionUri);


    public Repository()
    {

    }

    public IArtichokeGame GetGame(string key)
    {
        var filter = Builders<GameState>.Filter.Eq(r => r.key, key);
        var collection = client.GetDatabase("ArtichokesGames").GetCollection<GameState>("GameStateStrings");
        string gamestateString = collection.Find(filter).First().Game;
        return new ArtichokeGame(gamestateString);
    }

    public bool ContainsKey(string key)
    {
        var collection = client.GetDatabase("ArtichokesGames").GetCollection<GameState>("GameStateStrings");
        var filter = Builders<GameState>.Filter.Eq(r => r.key, key);
        return collection.Find(filter).CountDocuments() > 0;
    }

    public void Save(string key, string artichokeGameString)
    {
        var collection = client.GetDatabase("ArtichokesGames").GetCollection<GameState>("GameStateStrings");
        var filter = Builders<GameState>.Filter.Eq(r => r.key, key);
        if (collection.Find(filter).CountDocuments() > 0)
        {
            var update = Builders<GameState>.Update
                .Set(gameState => gameState.Game, artichokeGameString);
            collection.UpdateOne(filter, update);
        }
        else
        {
            collection.InsertOne(new GameState(key, artichokeGameString));
        }
    }

    public string GetGameString(string key)
    {
        var collection = client.GetDatabase("ArtichokesGames").GetCollection<GameState>("GameStateStrings");
        var filter = Builders<GameState>.Filter.Eq(r => r.key, key);
        return collection.Find(filter).First().Game;
    }
}

public class GameState
{
    public ObjectId Id { get; set; }
    public string key { get; set; }
    public string Game { get; set; }
    public GameState(string key, string Game)
    {
        this.key = key;
        this.Game = Game;
    }

}
