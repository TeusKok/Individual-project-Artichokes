using Artichokes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtichokesController : ControllerBase
{
    private Repository _repository;
     //required using Microsoft.AspNetCore.Http;  
         //required using System.Security.Claims;  
    

    public ArtichokesController(Repository repository)
    {
        _repository = repository;
    }
    [HttpPost()]
    [Consumes("application/json")]
    public IActionResult Post(Dictionary<string,string> names)
    {
       ArtichokeGame game = new ArtichokeGame(names["name1"],names["name2"],names["name3"],names["name4"]);
       ArtichokeGameDTO gameDTO= new ArtichokeGameDTO(game);
       _repository.save("test",game);
       return Ok(gameDTO);
    }
    [HttpPost("endturn")]
    public IActionResult PostEndTurn(Dictionary<string,string> body)
    {
        ArtichokeGame game = _repository.Get("test"); 
        int playerNumber = game.getPlayerNumberByName(body.First().Value);
        game.discardHand(playerNumber);
        game.refillHand(playerNumber);
        ArtichokeGameDTO gameDTO= new ArtichokeGameDTO(game);
        
        return Ok(gameDTO);
    }
}