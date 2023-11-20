<script setup lang="ts">

import { Player } from '../types';


    
  
    const props= defineProps<{player : Player}>()
</script>

<template>
    <div class = "container">
        <div>{{ props.player.discardPile.topCard.cardName }}</div>
    </div>
</template>

<style scoped>

</style>