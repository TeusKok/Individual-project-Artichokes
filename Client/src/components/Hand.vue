<script setup lang="ts">

    
    import { Card } from '../types';
    const props= defineProps<{cards : Card[],playerHasTurn:Boolean,}>();
    const emit = defineEmits<{
        (e: 'playCard', id: number): void
        }>()

    /* 
        <button v-if="props.cards.length>0" class="card" @click ="emit('playCard', 1)">{{ props.cards[0].cardName }} </button>
        <button v-if="props.cards.length>1" class="card" @click ="emit('playCard', 2)">{{ props.cards[1].cardName }} </button>
        <button v-if="props.cards.length>2" class="card" @click ="emit('playCard', 3)">{{ props.cards[2].cardName }} </button>
        <button v-if="props.cards.length>3" class="card" @click ="emit('playCard', 4)">{{ props.cards[3].cardName }} </button>
        <button v-if="props.cards.length>4" class="card" @click ="emit('playCard', 5)">{{ props.cards[4].cardName }} </button>
        <button v-if="props.cards.length>5" class="card" @click ="emit('playCard', 6)">{{ props.cards[5].cardName }} </button>
    */
</script>

<template>
    <div class="container">
        
        <button v-for="n in props.cards.length"  :disabled="!playerHasTurn||!props.cards[n-1].mayBePlayed" class = "playercard" @click ="emit('playCard', n)" >{{ props.cards[n-1].cardName }}</button>
    </div>
</template>

<style scoped>
.container{
    display: grid;
    grid-template-rows: 8rem;
    gap: 5px 5px;
}
.playercard{
    grid-row: 1 /-1;
    font-size: small;
    width:6rem;
    text-align:center;
}
</style>