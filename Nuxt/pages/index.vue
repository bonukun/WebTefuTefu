<template>
  <Header />
  <div class="container">
    <p>{{ datas }}</p>
    <textarea
      class="form-control"
      v-model="bibTeXString"
      rows="6"
      cols="80"
      placeholder="BibTeXを入力してください"
    ></textarea>
    <div class="buttons-arrangement">
      <button
        @click="sendBibTexString"
        class="btn btn-outline-primary"
        type="button"
      >
        送信
      </button>
    </div>
    <p v-if="processing">処理中...</p>
    <br />
    <textarea
      class="form-control"
      v-model="result"
      rows="6"
      cols="80"
      readonly
      >{{ result }}</textarea
    >
    <div class="buttons-arrangement">
      <button
        @click="copyClipBord"
        class="btn btn-outline-primary"
        type="button"
      >
        結果をコピーする
      </button>
    </div>
  </div>
</template>

<script setup lang="ts">
const runtimeConfig = useRuntimeConfig();
const apiUrl = runtimeConfig.public.apiUrlBase;
const url = apiUrl + "/Test";
const result = ref();
const bibTeXString = ref();
const processing = ref();
processing.value = false;
result.value = "ここに処理結果が表示されます";

const datas = ref();
datas.value = "";

const sendBibTexString = async () => {
  const url = apiUrl + "/BibTeX/postBibTeX";
  processing.value = true;
  console.log(url);
  try {
    const { data } = await useFetch(url, {
      method: "post",
      body: { bibTeXString: bibTeXString.value },
    });
    result.value = data.value.bibTeXResult;
    processing.value = false;
  } catch (e) {
    console.log(e);
    processing.value = false;
    result.value =
      "サーバーが応答を停止しているようです。後ほどお試しください。";
  }
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

<style>
button {
}

.buttons-arrangement {
  padding-top: 10px;
  text-align: right;
}
</style>
