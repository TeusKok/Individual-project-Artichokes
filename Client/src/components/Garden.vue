<script setup lang="ts">
import GardenSupplyComponent from './GardenSupplyComponent.vue' ;
import { GardenStock,GardenSupply } from '../types';
const props= defineProps<{gardenStock : GardenStock, gardenSupply : GardenSupply}>()   



    
</script>

<template>
    <div>
        <GardenSupplyComponent :cards = "props.gardenSupply.cards"></GardenSupplyComponent>
        There are {{gardenStock.numberOfCards}} cards in the gardenStock
    </div>
</template>

<style scoped>

</style>