<script setup lang="ts">

    
    import { Card } from '../types';
    const props= defineProps<{cards : Card[],playerHasTurn:Boolean,playerHasHarvestedOrGardenSupplyEmpty:Boolean}>();
    
    const emit = defineEmits(['playCard','showOptions']);
    const handlePlayCard = (value:number) => {
            emit('playCard',value)
        
    };
</script>

<template>
    <div class="container">
        
        <button v-for="n in props.cards.length"
            v-b-tooltip.hover  
            :title="props.cards[n-1].cardDescription"  
            :disabled="!playerHasTurn||!playerHasHarvestedOrGardenSupplyEmpty||!props.cards[n-1].mayBePlayed" 
            class = "playercard" 
            @click ="handlePlayCard(n)" 
        >
            {{ props.cards[n-1].cardName }}
        </button>
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