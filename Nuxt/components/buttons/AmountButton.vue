<template>
  <div class="buttons">
    <button class="minus" @click="$emit('decrease')" type="button">-</button>
    <button class="plus" @click="$emit('increase')" type="button">+</button>
  </div>
</template>

<script setup lang="ts">
defineEmits(["increase", "decrease"]);
</script>

<style>
.plus {
  background-color: rgb(255, 68, 0);
  font-size: large;
  border-radius: 100%;
  border: none;
  width: 40px;
  height: 40px;
}
.minus {
  background-color: aqua;
  font-size: large;
  border-radius: 50%;
  border: none;
  width: 40px;
  height: 40px;
}
</style>
