<script setup lang="ts">


import { Player } from '../types';

const props= defineProps<{player : Player, choiceNeeded: boolean}>();
const emit = defineEmits(['endTurn']);
 

</script>

<template>
    <div class = "container">
        <button class = "drawPile" 
            @click="emit('endTurn')"
            v-b-tooltip.hover 
            title="Click to end your turn"
            :disabled="!player.hasTurn||!player.harvestedCard||choiceNeeded" 
        >
            Drawpile: {{ props.player.drawPile.numberOfCards }} cards
        </button>
    </div>
</template>

<style scoped>
    .drawPile{
        width:6rem;
        height:8rem;
        text-align:center;
        font-size: small;
    }
</style>