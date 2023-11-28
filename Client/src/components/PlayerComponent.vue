<script setup lang="ts">

    
import { Player } from '../types';

import DiscardPile from './DiscardPile.vue';
import DrawPile from './DrawPile.vue';
import Hand from './Hand.vue';
 
const props= defineProps<{player : Player,gardenSupplyEmpty: Boolean}>()
const emit = defineEmits(['endTurn','playCard']);
const handlePlayCard = (value:number) => {
  emit('playCard',value)
};

</script>


<template>
    <div class="player">
        <div :class= "{active: props.player.hasTurn}"> {{props.player.name}}   </div>
        <Hand :cards = "props.player.hand.cards" :playerHasTurn ="props.player.hasTurn" :playerHasHarvestedOrGardenSupplyEmpty="props.player.harvestedCard||props.gardenSupplyEmpty" @playCard = "handlePlayCard" ></Hand>
        <div class = "piles">
        <DrawPile :player = "props.player"  @endTurn = "emit('endTurn')" ></DrawPile>
        <DiscardPile :player = "props.player"></DiscardPile>
        </div>
    </div>
</template>

<style scoped>
.player {
    width: 50%;
    height: 50%;
    display:grid;
    justify-content: center;
    gap: 4px;
}
.active{
    color: green;
    font-size: x-large;
    


}
.piles{
    display: grid;
    grid-template-rows: auto;
    grid-template-columns: auto auto;
}
</style>