<template>
  <select class="custom-select-box">
    <option
      v-for="selectNumber in selectNumbers"
      :key="selectNumber"
      :value="selectNumber"
    >
      {{ selectNumber }}人
    </option>
  </select>
</template>

<script lang="ts" setup>
const authorNumber: Ref<number> = ref(0);
const selectNumbers = [
  1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
];

interface Props {
  selectChoices: [string];
}
</script>

<style>
.custom-select-box {
  background: #fbfbff;
  text-align: center;
  height: 40px;
  width: 150px;
  border-radius: 5px;
  position: relative;
  z-index: 1;
}
</style>
