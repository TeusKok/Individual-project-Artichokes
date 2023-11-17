<script setup lang="ts">
import { ref } from 'vue'
const response = await fetch("http://localhost:5173/api/artichokes",{
    method: 'POST',
    headers: {
        Accept: "application/json",
            "Content-Type": "application/json",
    },
    body: JSON.stringify({
      name1:"piet",
      name2:"joop",
      name3:"jan",
      name4:"jaap",
    }),
  })

const result = await response.json();



const rresult = ref(result)
//const forecast = ref(weatherforecast)
</script>

<template>
    <div>{{ rresult }} </div>
</template>

<style scoped>
.read-the-docs {
  color: #3228c5;
}
</style>