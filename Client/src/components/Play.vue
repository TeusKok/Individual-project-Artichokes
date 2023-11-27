<script setup lang="ts">
  import { ref } from 'vue'
  import { ArtichokesGame } from '../types';
 

  import PlayerComponent from './PlayerComponent.vue';
  import Garden from './Garden.vue';
  import { endTurn, harvestCard, playCard } from '../services/api';

  const response = await fetch("http://localhost:5173/api/artichokes",{
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
      }),
    })

  const result = await response.json();
  const game = ref(result as ArtichokesGame );

</script>



<template>
  <div class = "gamecontainer" v-if="!game.gameStatus.gameOver">
    <PlayerComponent :player = "game.players[0]" @endTurn = endTurn(game,0) @playCard="(value:number)=>{playCard(game,value)}" />
    <PlayerComponent :player = "game.players[1]" @endTurn = endTurn(game,1) @playCard="(value:number)=>{playCard(game,value)}"/>
    <Garden class = "wide" :gardenStock ="game.gardenStock" :gardenSupply ="game.gardenSupply" 
        @harvest ="(value:number)=>{harvestCard(game,value)}"></Garden>
    <PlayerComponent :player = "game.players[3]" @endTurn = endTurn(game,3) @playCard="(value:number)=>{playCard(game,value)}"/>
    <PlayerComponent :player = "game.players[2]" @endTurn = endTurn(game,2) @playCard="(value:number)=>{playCard(game,value)}"/>
  </div>
  <div v-if="game.gameStatus.gameOver">Game Over: {{ game.gameStatus.winner }} has won</div>
</template>

<style scoped>
.read-the-docs {
  color: #3228c5;
}
.gamecontainer{
    display: grid;
    grid-template-columns: 50% 50%  ;
    grid-template-rows: auto 12rem auto ;
    gap: 20px 20px;
    height:inherit;
    justify-items: center;
}
.wide{
  grid-column: 1/span 2 ;
}
</style> 


