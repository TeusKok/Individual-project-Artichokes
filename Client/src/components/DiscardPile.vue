<script setup lang="ts">

import { Player } from '../types';
    const props= defineProps<{player : Player}>()
</script>

<template>
    <div class = "container">
        <button class ="discardPile" disabled="true">{{ props.player.discardPile.topCard.cardName }}</button>
    </div>
</template>

<style scoped>
    .discardPile{
        height:8rem;
        width: 6rem;

    }
</style>