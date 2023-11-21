<script setup lang="ts">

import { Player } from '../types';
const props= defineProps<{player : Player}>()   



    
</script>

<template>
    <div class = "container">
        <button class = "drawPile" >Number Of cards in drawPile: {{ props.player.drawPile.numberOfCards }}</button>
    </div>
</template>

<style scoped>

</style>