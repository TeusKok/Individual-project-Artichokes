<script setup lang="ts">

    
    import { Card } from '../types.js';
    const props= defineProps<{cards : Card[]}>()
</script>

<template>
    <div class="container">
        <button class="card">{{ props.cards[0].cardName }} </button>
        <button class="card">{{ props.cards[1].cardName }} </button>
        <button class="card">{{ props.cards[2].cardName }} </button>
        <button class="card">{{ props.cards[3].cardName }} </button>
        <button class="card">{{ props.cards[4].cardName }} </button>
    </div>
</template>

<style scoped>
.container{
    display: grid;
    grid-template-columns: auto auto auto auto auto ;
    grid-template-rows: auto auto auto auto ;
    gap: 5px 5px;
}
.card{
    grid-row: 1/span 4 ;
    font-size: small;
}
</style>