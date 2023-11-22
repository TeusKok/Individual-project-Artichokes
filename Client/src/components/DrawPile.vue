<script setup lang="ts">


import { Player } from '../types';

const props= defineProps<{player : Player}>();
const emit = defineEmits(['endTurn']);
 



    
</script>

<template>
    <div class = "container">
        <button class = "drawPile" @click="emit('endTurn') " :disabled="!player.hasTurn" >Number Of cards in drawPile: {{ props.player.drawPile.numberOfCards }}</button>
    </div>
</template>

<style scoped>

</style>