<script setup lang="ts">
    import { Card } from '../types.js';

    const props= defineProps<{cards : Card[],cardHarvestingAllowed:boolean}>()
    const emit = defineEmits<{
        (e: 'harvest', id: number): void
        }>()

</script>

<template>
    <div class="container">
        <button v-for="n in props.cards.length" :disabled="!props.cardHarvestingAllowed " class = "card" @click ="emit('harvest', n)" >{{ props.cards[n-1].cardName }} </button>
    </div>
</template>

<style scoped>
.container{
    display: grid;
    width: min-content;
    
    grid-template-rows: auto;
    gap: 5px 5px;
}
.card{
    grid-row: 1/-1;
    font-size: small;
    width: 6rem;
}
</style>