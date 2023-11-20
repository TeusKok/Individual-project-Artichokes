<script setup lang="ts">
  import { ref } from 'vue'
  import { ArtichokesGame } from '../types';

  import Player from './Player.vue';
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
    <Player
      v-for = "player in rresult.players"
      :player = "player"  
    />
  </div>
</template>

<style scoped>
.read-the-docs {
  color: #3228c5;
}
.container{
    display: grid;
    grid-template-columns: auto auto  ;
    grid-template-rows: auto auto ;
    gap: 20px 20px;
    height:inherit
}
</style> 


