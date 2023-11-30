<script setup lang="ts">
import { ArtichokesGame, CardNumberWithAnswer } from '../types';
import { endTurn, playCard} from '../services/api';
import PlayerComponent from './PlayerComponent.vue';


const props= defineProps<{game: ArtichokesGame, index: number}>();


</script>

<template>
    <PlayerComponent :player = "props.game.players[props.index]" 
        :gardenSupplyEmpty = "props.game.gardenSupply.cards.length==0" 
        @endTurn = endTurn(props.game,props.index) 
        @playCard="(response:CardNumberWithAnswer)=>{playCard(props.game,response.cardNumber,response.answer)}" />
</template>

<style scoped>

</style>