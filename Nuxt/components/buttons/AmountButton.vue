<template>
  <div class="buttons">
    <button @click="$emit('decrease')" class="btn btn-primary" type="button">
      -
    </button>
    <button @click="$emit('increase')" class="btn btn-danger" type="button">
      +
    </button>
  </div>
</template>

<script setup lang="ts" setup>
defineEmits(["increase", "decrease"]);
</script>

<style>
button {
  margin: 0 10px;
}
.buttons {
  text-align: right;
}
</style>
