<script setup lang="ts">

    
import { Player } from '../types';
import { ArtichokesGame } from '../types';
import DiscardPile from './DiscardPile.vue';
import DrawPile from './DrawPile.vue';
import Hand from './Hand.vue';
/*
const onClick = async(player: Player) => {
     
     const response = await fetch("http://localhost:5173/api/artichokes/endturn",{
       method: 'POST',
       headers: {
           Accept: "application/json",
               "Content-Type": "application/json",
       },
       body: JSON.stringify({
         playerName:player.name,
       }),
     })
 
    const result = await response.json();
    const rresult = result as ArtichokesGame
    player.discardPile = rresult.players[0].discardPile
    player.drawPile = rresult.players[0].drawPile

     
 }
 */ 
const props= defineProps<{player : Player}>()
</script>
<script lang="ts">
    export default {
    data () {
       return this.player; 
    },
    methods: {
        async buttonClick (player: Player) {
            const response = await fetch("http://localhost:5173/api/artichokes/endturn",{
                method: 'POST',
                headers: {
                    Accept: "application/json",
                        "Content-Type": "application/json",
                },
                body: JSON.stringify({
                    playerName:player.name,
                    test:"test",
                }),
            })
 
            const result = await response.json();
            const rresult = result as ArtichokesGame;
            console.log(rresult.players);
            console.log(rresult.players.find((x)=> x.name === player.name))
            let newPlayer = rresult.players.find((x)=> x.name === player.name);
            player.discardPile = newPlayer.discardPile;
            player.drawPile = newPlayer.drawPile;
            player.hand = newPlayer.hand;
            
        }
    },
}
</script>

<template>
    <div class="player">
        <div> {{props.player.name}}  </div>
        <Hand :cards = "props.player.hand.cards" ></Hand>
        <DrawPile :player = "props.player" @click = "buttonClick(player)" ></DrawPile>
        <DiscardPile :player = "props.player"></DiscardPile>
    </div>
</template>

<style scoped>
.player {
    width: 1/2;
    height: 1/2;
}
</style>