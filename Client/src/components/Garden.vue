<script setup lang="ts">
import GardenSupplyComponent from './GardenSupplyComponent.vue' ;
import { GardenStock,GardenSupply } from '../types';
const props= defineProps<{gardenStock : GardenStock, gardenSupply : GardenSupply,}>()  ;
const emit = defineEmits(['harvest']) ;
const handleHarvest = (value:number) => {
  emit('harvest',value)
};


    
</script>

<template>
    <div class="container1">
        <GardenSupplyComponent :cards = "props.gardenSupply.cards" :cardHarvestingAllowed ="props.gardenSupply.cardHarvestingAllowed" @harvest ="handleHarvest" ></GardenSupplyComponent>
        There are {{gardenStock.numberOfCards}} cards in the gardenStock{{ props.gardenSupply.cardHarvestingAllowed }}
    </div>
</template>

<style scoped>
  .container1{
    display:grid;
    grid-template-columns: auto;
    grid-template-rows: 8rem 3rem;
    justify-content: center;
    height:11rem;
  }
</style>