<script setup lang="ts">

    
import { Player } from '../types';

import DiscardPile from './DiscardPile.vue';
import DrawPile from './DrawPile.vue';
import Hand from './Hand.vue';
 
const props= defineProps<{player : Player}>()
const emit = defineEmits(['endTurn','playCard']);
const handlePlayCard = (value:number) => {
  emit('playCard',value)
};

</script>


<template>
    <div class="player">
        <div :class= "{active: props.player.hasTurn}"> {{props.player.name}}   </div>
        <Hand :cards = "props.player.hand.cards" :playerHasTurn ="props.player.hasTurn" @playCard = "handlePlayCard" ></Hand>
        <DrawPile :player = "props.player"  @endTurn = "emit('endTurn')" ></DrawPile>
        <DiscardPile :player = "props.player"></DiscardPile>
    </div>
</template>

<style scoped>
.player {
    width: 1/2;
    height: 1/2;
}
.active{
    color: green;
    font-size: x-large;
    


}
</style>