<script setup lang="ts">

import { Player } from '../types';
const props= defineProps<{player : Player, onClick: ()=>void}>()   



    
</script>

<template>
    <div class = "container">
        <button class = "drawPile" @click="onClick">Number Of cards in drawPile: {{ props.player.drawPile.numberOfCards }}</button>
    </div>
</template>

<style scoped>

</style>