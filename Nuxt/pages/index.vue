<template>
    <h1>書誌情報生成する君</h1>
    <button @click="addTask">test</button>
    <p>{{ count }}</p>

</template>

<script setup lang="ts">
const url = "内緒";

let count = ref(0);
const countUp = (): number => {
  return count.value++;
};

const addTask = () => {
  const { data } = useFetch(url, {
    method: 'get'
  });
  console.log("test")
  console.log(data)
};

</script>
