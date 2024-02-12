<template>
    <h1>書誌情報生成する君</h1>
    <button @click="addTask">test</button>
    <p>{{datas}}</p>

</template>

<script setup lang="ts">
const url = "http://localhost:8080/WeatherForecast";

const datas =ref()

const addTask = async () => {
  const { data } = await useFetch(url, {
    method: 'get'
  });
  datas.value=data.value;
  console.log("test")
  console.log(data)
};

</script>
