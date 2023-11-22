using Artichokes;
using Repositories;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtichokesController : ControllerBase
{
    private IRepository _repository; 
    

    public ArtichokesController(IRepository repository)
    {
        _repository = repository;
    }
    [HttpPost()]
    [Consumes("application/json")]
    public IActionResult Post(Dictionary<string,string> names)
    {
       IArtichokeGame game = new ArtichokeGame(names["name1"],names["name2"],names["name3"],names["name4"]);
       ArtichokeGameDTO gameDTO= new ArtichokeGameDTO(game);
       _repository.Save("test",game);
       return Ok(gameDTO);
    }
    [HttpPost("endturn")]
    [Consumes("application/json")]
    public IActionResult PostEndTurn(Dictionary<string,string> body)
    {
        IArtichokeGame game = _repository.Get("test"); 
        int playerNumber = game.getPlayerNumberByName(body.First().Value);
        game.discardHand(playerNumber);
        game.refillHand(playerNumber);
        game.endTurn(playerNumber);
        game.getPlayerByNumber(1).SharedGardenSupply.refillGardenSupply();
        ArtichokeGameDTO gameDTO= new ArtichokeGameDTO(game);
        
        return Ok(gameDTO);
    }
    [HttpPost("harvest")]
    [Consumes("application/json")]
    public IActionResult PostHarvest(Dictionary<string,string> body)
    {
        IArtichokeGame game = _repository.Get("test"); 
        Player player = game.getActivePlayer();
        player.HarvestCardFromGardenSupply(Int32.Parse(body.First().Value));
        ArtichokeGameDTO gameDTO= new ArtichokeGameDTO(game);
        
        return Ok(gameDTO);

    }

    [HttpPost("playcard")]
    [Consumes("application/json")]
    public IActionResult PostPlayCard(Dictionary<string,string> body)
    {
        IArtichokeGame game = _repository.Get("test"); 
        Player player = game.getActivePlayer();
        player.PlayCardFromHandByNumber(Int32.Parse(body.First().Value));
        ArtichokeGameDTO gameDTO= new ArtichokeGameDTO(game);
        
        return Ok(gameDTO);
    }
}