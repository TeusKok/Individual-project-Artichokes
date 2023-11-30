<script setup lang="ts">

    import { Card } from '../types';
    const props= defineProps<{card : Card}>();
    const emit = defineEmits(['choice']);
</script>

<template>
    <div v-for="m in props.card.options.length" class = "container">
        <button  v-for="n in props.card.options[m-1].answers.length"
            v-b-tooltip.hover  
            :title="props.card.options[m-1].question"  
            class = "choice" 
            @click ="emit('choice',props.card.options[m-1].answers[n-1])" 
        >
            {{ props.card.options[m-1].answers[n-1] }}
        </button>
    </div>
</template>

<style scoped>
    .container{
    display: grid;
    grid-template-rows: 8rem;
    gap: 5px 5px;
    }
    .choice{
        grid-row: 1 /-1;
        font-size: small;
        width:6rem;
        text-align:center;
    }
</style>