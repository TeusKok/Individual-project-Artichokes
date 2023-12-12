<script setup lang="ts">

    
import { Player, CardNumberWithAnswer } from '../types';
import { ref } from 'vue'
import DiscardPile from './DiscardPile.vue';
import DrawPile from './DrawPile.vue';
import Hand from './Hand.vue';
import Choice from './Choice.vue';
 
const props= defineProps<{player : Player,gardenSupplyEmpty: Boolean}>()
const emit = defineEmits(['endTurn','playCard']);
const choiceNeeded = ref(false);
const cardNumber = ref(1);
const handlePlayCard = (value:number) => {
    if(props.player.hand.cards[value-1].option.answers.length>0){
        choiceNeeded.value = true;
        cardNumber.value = value;
    }
    else{
        const response: CardNumberWithAnswer ={
        cardNumber: value,
        answer: ""
        };
        emit('playCard',response);
    }
  
};

const handlePlayCardWithOptions =(choice:string) =>{
    choiceNeeded.value = false;
    const response: CardNumberWithAnswer ={
        cardNumber: cardNumber.value,
        answer: choice
    };
    emit('playCard', response);
}

</script>


<template>
    <div class="player">
        <div :class= "{active: props.player.hasTurn}"> {{props.player.name}}   </div>
        <Hand :cards = "props.player.hand.cards"
            v-if ="!choiceNeeded" 
            :playerHasTurn ="props.player.hasTurn" 
            :playerHasHarvestedOrGardenSupplyEmpty="props.player.harvestedCard||props.gardenSupplyEmpty" 
            @playCard = "handlePlayCard" 
        />
        <Choice v-if ="choiceNeeded" 
            :card = "props.player.hand.cards[cardNumber-1]"
            @choice ="handlePlayCardWithOptions"
        />
        <div class = "piles">
            <DrawPile :player = "props.player" :choiceNeeded ="choiceNeeded" @endTurn = "emit('endTurn')" />
            <DiscardPile :player = "props.player"/>
        </div>
    </div>
</template>

<style scoped>
.player {
    width: 50%;
    height: 50%;
    display:grid;
    justify-content: center;
    gap: 4px;
}
.active{
    color: green;
    font-size: x-large;
}
.piles{
    display: grid;
    grid-template-rows: auto;
    grid-template-columns: auto auto;
}
</style>