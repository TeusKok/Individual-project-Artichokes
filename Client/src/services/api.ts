import { ArtichokesGame } from "../types";
export async function endTurn (oldGame: ArtichokesGame, playerIndex:number) {
    const response = await fetch("http://localhost:5173/api/artichokes/endturn",{
        method: 'POST',
        headers: {
            Accept: "application/json",
                "Content-Type": "application/json",
        },
        body: JSON.stringify({
            playerName:oldGame.players[playerIndex].name,
        }),
    })
    
    const result = await response.json();
    const newGame = result as ArtichokesGame;
    oldGame.players = newGame.players;
    oldGame.gardenStock = newGame.gardenStock;
    oldGame.gardenSupply = newGame.gardenSupply;
    
}
export async function harvestCard (oldGame: ArtichokesGame, cardNumber:number){
  console.log(cardNumber);
  const response = await fetch("http://localhost:5173/api/artichokes/harvest",{
        method: 'POST',
        headers: {
            Accept: "application/json",
                "Content-Type": "application/json",
        },
        body: JSON.stringify({
            cardToPlay:cardNumber+"",
        }),
    })
    
    const result = await response.json();
    const newGame = result as ArtichokesGame;
    oldGame.players = newGame.players;
    oldGame.gardenSupply = newGame.gardenSupply;
}
export async function playCard (oldGame: ArtichokesGame, cardNumber:number){
  console.log(cardNumber);
  const response = await fetch("http://localhost:5173/api/artichokes/playcard",{
        method: 'POST',
        headers: {
            Accept: "application/json",
                "Content-Type": "application/json",
        },
        body: JSON.stringify({
            cardToPlay:cardNumber+"",
        }),
    })
    
    const result = await response.json();
    const newGame = result as ArtichokesGame;
    oldGame.players = newGame.players;
    oldGame.gardenStock = newGame.gardenStock;
    oldGame.gardenSupply = newGame.gardenSupply;
}