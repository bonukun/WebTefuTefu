<template>
  <h1>書誌情報生成する君</h1>
  <p>{{ datas }}</p>
  <textarea
    v-model="bibTeXString"
    rows="3"
    cols="50"
    placeholder="BibTeXを入力してください"
  ></textarea>
  <br />
  <button @click="addTask">送信</button>
  <textarea v-moder="result" rows="3" cols="50" readonly></textarea>
</template>

<script setup lang="ts">
const runtimeConfig = useRuntimeConfig();
const apiurl = runtimeConfig.public.apiUrlBase;
const url = apiurl + "/Test";
const text = ref();
const result = ref();
const bibTeXString = ref();
result.value = "ここに処理結果が表示されます";

const datas = ref();
datas.value = "いえええい";

const addTask = async () => {
  const { data } = await useFetch(url, {
    method: "get",
  });
  console.log(url);
  datas.value = data.value;
  console.log("処理実行");
  console.log(runtimeConfig.public.apiUrlBase);
  console.log(process.env.NUXT_PUBLIC_API_URL);
};
</script>
