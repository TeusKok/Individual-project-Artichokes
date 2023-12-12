import { ArtichokesGame } from "../types";
export async function endTurn (oldGame: ArtichokesGame, playerIndex:number) {
    const Id = localStorage.getItem("Id")? localStorage.getItem("Id"):"404";
    const response = await fetch("http://localhost:5173/api/artichokes/endturn",{
        method: 'POST',
        headers: {
            Accept: "application/json",
                "Content-Type": "application/json",
        },
        body: JSON.stringify({
            playerName:oldGame.players[playerIndex].name,
            Id:Id,
        }),
    })
    
    const result = await response.json();
    const newGame = result as ArtichokesGame;
    oldGame.players = newGame.players;
    oldGame.gardenStock = newGame.gardenStock;
    oldGame.gardenSupply = newGame.gardenSupply;
    oldGame.gameStatus = newGame.gameStatus;
    
}
export async function harvestCard (oldGame: ArtichokesGame, cardNumber:number){
    const Id = localStorage.getItem("Id")? localStorage.getItem("Id"):"404";
    const response = await fetch("http://localhost:5173/api/artichokes/harvest",{
        method: 'POST',
        headers: {
            Accept: "application/json",
                "Content-Type": "application/json",
        },
        body: JSON.stringify({
            cardToPlay:cardNumber+"",
            Id:Id,
        }),
    })
    
    const result = await response.json();
    const newGame = result as ArtichokesGame;
    oldGame.players = newGame.players;
    oldGame.gardenSupply = newGame.gardenSupply;
}
export async function playCard (oldGame: ArtichokesGame, cardNumber:number, selectedOption:string){
    const Id = localStorage.getItem("Id")? localStorage.getItem("Id"):"404";
    const response = await fetch("http://localhost:5173/api/artichokes/playcard",{
        method: 'POST',
        headers: {
            Accept: "application/json",
                "Content-Type": "application/json",
        },
        body: JSON.stringify({
            cardToPlay:cardNumber+"",
            Id:Id,
            selectedOption:selectedOption,
        }),
    })
    
    const result = await response.json();
    const newGame = result as ArtichokesGame;
    oldGame.players = newGame.players;
    oldGame.gardenStock = newGame.gardenStock;
    oldGame.gardenSupply = newGame.gardenSupply;
    oldGame.gameStatus = newGame.gameStatus;
}
export async function newGame(oldGame: ArtichokesGame){
    const Id = localStorage.getItem("Id")? localStorage.getItem("Id"):"404";
    const response = await fetch("http://localhost:5173/api/artichokes/newgame",{
      method: 'POST',
      headers: {
          Accept: "application/json",
              "Content-Type": "application/json",
      },
      body: JSON.stringify({
        name1:"Piet",
        name2:"Joop",
        name3:"Jan",
        name4:"Jaap",
        Id:Id,
      }),
    })

    const result = await response.json();
    const newGame = result as ArtichokesGame;
    oldGame.players = newGame.players;
    oldGame.gardenStock = newGame.gardenStock;
    oldGame.gardenSupply = newGame.gardenSupply;
    oldGame.gameStatus = newGame.gameStatus;
}