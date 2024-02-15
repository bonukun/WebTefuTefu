<template>
  <h1>書誌情報生成する君</h1>
  <p>{{ datas }}</p>
  <textarea
    v-model="bibTeXString"
    rows="6"
    cols="80"
    placeholder="BibTeXを入力してください"
  ></textarea>
  <br />
  <button @click="sendBibTexString">送信</button>
  <br />
  <textarea v-model="result" rows="6" cols="80" readonly>{{ result }}</textarea>
  <br />
  <button @click="copyClipBord">結果をコピーする</button>
</template>

<script setup lang="ts">
const runtimeConfig = useRuntimeConfig();
const apiUrl = runtimeConfig.public.apiDevelopUrlBase;
const url = apiUrl + "/Test";
const result = ref();
const bibTeXString = ref();
result.value = "ここに処理結果が表示されます";

const datas = ref();
datas.value = "";

const sendBibTexString = async () => {
  const url = apiUrl + "/BibTeX/postBibTeX";
  console.log(url);
  const { data } = await useFetch(url, {
    method: "post",
    body: { bibTeX: bibTeXString.value },
  });
  result.value = data.value.resultBibTeX;
};

const copyClipBord = () => {
  console.log("クリップボードをコピーする関数処理が実行されました。");
  navigator.clipboard.writeText(result.value);
};

const testApi = async () => {
  const { data } = await useFetch(url, {
    method: "get",
  });
  console.log(url);
  data.value = data.value;
  console.log(data);
};
</script>
