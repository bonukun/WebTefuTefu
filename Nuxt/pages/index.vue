<template>
    <h1>書誌情報生成する君</h1>
    <button @click="addTask">test</button>
    <p>{{datas}}</p>

</template>

<script setup lang="ts">
const runtimeConfig = useRuntimeConfig();
const url = `${runtimeConfig.public.apiUrl}/Test`;

const datas =ref()

const addTask = async () => {
  const { data } = await useFetch(url, {
    method: 'get'
  });
  datas.value=data.value;
};

</script>
