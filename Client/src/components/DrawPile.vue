<script setup lang="ts">


import { Player } from '../types';

const props= defineProps<{player : Player}>();
const emit = defineEmits(['endTurn']);
 



    
</script>

<template>
    <div class = "container">
        <button class = "drawPile" @click="emit('endTurn') " :disabled="!player.hasTurn" >Drawpile: {{ props.player.drawPile.numberOfCards }} cards Click to End Turn</button>
    </div>
</template>

<style scoped>
    .drawPile{
        width:6rem;
        height:8rem;
    }
</style>