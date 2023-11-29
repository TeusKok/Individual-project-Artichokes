<script setup lang="ts">
  import { ref } from 'vue'
  import { ArtichokesGame } from '../types';
  import PlayerConstructor from './PlayerConstructor.vue';
  import Garden from './Garden.vue';
  import { harvestCard, newGame } from '../services/api';

  
  const Id = localStorage.getItem("Id")? localStorage.getItem("Id"):"404";
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
        Id:Id,
      }),
    })
    

  const result = await response.json();
  const game = ref(result as ArtichokesGame );
  localStorage.setItem("Id",game.value.gameId);

</script>



<template>
  <div class = "gamecontainer" v-if="!game.gameStatus.gameOver">
    <PlayerConstructor :game = "game" :index = "0" ></PlayerConstructor>
    <PlayerConstructor :game = "game" :index = "1" ></PlayerConstructor>

    <Garden class = "wide" 
      :gardenStock ="game.gardenStock" 
      :gardenSupply ="game.gardenSupply" 
      @harvest ="(value:number)=>{harvestCard(game,value)}"
    >
    </Garden>

    <PlayerConstructor :game = "game" :index = "3" ></PlayerConstructor>
    <PlayerConstructor :game = "game" :index = "2" ></PlayerConstructor>
  </div>
  <div v-if="game.gameStatus.gameOver">
    Game Over: {{ game.gameStatus.winner }} has won 
    <button @click="newGame(game)">
      Click for a new game
    </button>
  </div>
  
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


