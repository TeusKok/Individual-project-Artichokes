<script setup lang="ts">
  import { ref } from 'vue'
  import { ArtichokesGame } from '../types';

  import Player from './Player.vue';
  import Garden from './Garden.vue';
  const response = await fetch("http://localhost:5173/api/artichokes",{
      method: 'POST',
      headers: {
          Accept: "application/json",
              "Content-Type": "application/json",
      },
      body: JSON.stringify({
        name1:"piet",
        name2:"joop",
        name3:"jan",
        name4:"jaap",
      }),
    })

  const result = await response.json();



  const rresult = ref(result as ArtichokesGame )

  //const forecast = ref(weatherforecast)

</script>


<template>
  <div class = "container">
    <Player :player = "rresult.players[0]"  />
    <Player :player = "rresult.players[1]"  />
    <Garden class = "wide" :gardenStock ="rresult.gardenStock" :gardenSupply ="rresult.gardenSupply"></Garden>
    <Player :player = "rresult.players[3]"  />
    <Player :player = "rresult.players[2]"  />
  </div>
</template>

<style scoped>
.read-the-docs {
  color: #3228c5;
}
.container{
    display: grid;
    grid-template-columns: auto auto  ;
    grid-template-rows: auto auto auto ;
    gap: 20px 20px;
    height:inherit
}
.wide{
  grid-column: 1/span 2 ;
}
</style> 


