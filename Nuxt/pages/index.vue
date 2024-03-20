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
    <InputsInputForm placeHolder="BibTeXを入力してください。" />
    <div class="author-input-field">
      <h3>著者入力</h3>

      <div class="form-group" v-for="field in authorNumber" :key="field">
        <p style="margin-bottom: 0px">第{{ field }}著者</p>
        <div class="row">
          <div class="col-4">
            <input
              class="form-control"
              type="text"
              placeholder="姓 (LastName)"
            />
          </div>
          <div class="col-4">
            <input class="form-control" type="text" placeholder="middleName" />
          </div>
          <div class="col-4">
            <input
              class="form-control"
              type="text"
              placeholder="名 (FirstName)"
            />
          </div>
        </div>
      </div>
    </div>
    <ButtonsAmountButton
      @increase="authorIncrease"
      @decrease="authorDecrease"
    />
    <div>
      <hr />
    </div>
    <div
      class="row input-bib"
      style="display: flex"
      v-for="bibtexField in bibtexFields"
    >
      <label
        class="col-sm-2 control-label"
        :class="{ 'text-danger': bibtexField === 'Year' }"
        >{{ bibtexField }}</label
      >
      <div class="col-sm-10">
        <input class="form-control" style="width: 70%" type="text" />
      </div>
    </div>
    <div>
      <hr />
    </div>
    <div class="form-group" style="display: flex">
      <label class="col-sm-2 control-label">書式選択</label>
      <div class="col-sm-10">
        <input class="form-control" type="text" />
      </div>
    </div>
    <div class="form-group" style="display: flex">
      <label class="col-sm-2 control-label">メディア選択</label>
      <div class="col-sm-10">
        <input class="form-control" type="text" />
      </div>
    </div>
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
import { BibTeXMap } from "../types/BibtexMap";

const runtimeConfig = useRuntimeConfig();
const apiUrl = runtimeConfig.public.apiUrlBase;
const url = apiUrl + "/Test";
const result = ref();
const bibTeXString = ref();
const processing = ref();
const authorNumber: Ref<number> = ref(1);
const bibTexMap = new BibTeXMap();

const bibtexFields = ref(
  bibTexMap
    .getMemberVariableNames()
    .filter((field) => field !== "Author" && field !== "Editor")
);
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
  console.log(bibtexFields.value);

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

const authorIncrease = () => {
  authorNumber.value += 1;
};

const authorDecrease = () => {
  if (authorNumber.value != 1) {
    authorNumber.value -= 1;
  }
};
</script>

<style>
.buttons-arrangement {
  padding-top: 10px;
  text-align: right;
}

.form-group {
  padding: 10px;
}

.style-input-field {
  display: flex;
}

.input-bib {
  margin-top: 10px;
}
</style>
../types/BibTexMap
