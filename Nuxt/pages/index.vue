<template>
  <v-container>
    <h1>書誌情報つくる君</h1>
    <v-select
      v-model="default_style"
      label="参考文献リストの書式を選択"
      :items="['日本心理学会執筆・投稿の手びき_2015年改訂版']"
      variant="underlined"
      return-object
    ></v-select>
    <v-select
      label="登録する文献の言語を選択"
      v-model="language"
      :items="['邦文(日本語)', '欧文(外国語)']"
      @update:model-value=""
      variant="underlined"
      return-object
    ></v-select>
    <v-select
      label="参考文献の形態を選択"
      :items="['雑誌論文', '図書', 'ウェブサイト']"
      @update:model-value="mediaChange"
      variant="underlined"
      return-object
    ></v-select>
    <!-- <v-textarea label="BibTeXペースト欄"></v-textarea> -->
    <v-btn
      @click="handleButtonClick"
      class="text-capitalize"
      style="margin-bottom: 16px"
      >BibTeXから書式事項を抽出</v-btn
    >
    <v-row>
      <v-col>
        <v-text-field
          v-model="authorNum"
          label="著者の人数を入力"
          type="number"
          @input="authorNum_limit"
          max="20"
          min="1"
        ></v-text-field>
      </v-col>
      <v-col>
        <v-btn icon color="red" style="margin-right: 16px" @click="author_add">
          <v-icon>mdi-plus</v-icon>
        </v-btn>
        <v-btn icon color="blue" @click="author_remove">
          <v-icon>mdi-minus</v-icon>
        </v-btn>
      </v-col>
    </v-row>
    <v-row v-for="n in parseInt(authorNum.toString())" :key="n">
      <v-col>
        <v-text-field
          :label="`第${n}著者の名字を入力`"
          variant="underlined"
          v-model="authorLastNames[n - 1]"
        >
        </v-text-field>
      </v-col>
      <v-col>
        <v-text-field
          :label="`第${n}著者の名前を入力`"
          variant="underlined"
          v-model="authorFirstNames[n - 1]"
        >
        </v-text-field>
      </v-col>
    </v-row>
    <v-row v-for="(item, index) in input_value" :key="index">
      <v-text-field
        v-model="input_data[index]"
        :label="`${item}を入力`"
      ></v-text-field>
    </v-row>
    <v-textarea label="出力結果" variant="outlined"></v-textarea>
  </v-container>
</template>

<script setup lang="ts">
import { Article } from "~/types/jpa_style/article";
// import { base_ref } from "~/types/jpa_style/article";
const default_style = "日本心理学会執筆・投稿の手びき_2015年改訂版";
const article = new Article();

//現在変数出力用として使用
const handleButtonClick = () => {
  // console.log(article.title);
  // console.log(language.value);
  // console.log(authorFirstNames.value);
  // console.log(authorLastNames.value);
  getList();
  parsebib();
  // console.log(authorList.value);
  // console.log(input_data);
};

// 著者の人数に関係する処理群
const authorNum = ref(1);
const authorNum_limit = () => {
  console.log(authorNum.value);
  if (authorNum.value > 20) {
    authorNum.value = 20;
  }
};

const author_add = () => {
  if (authorNum.value == 20) {
    return;
  }
  authorNum.value++;
};
const author_remove = () => {
  if (authorNum.value == 1) {
    return;
  }
  authorNum.value--;
};

//language変更に関する処理群
const language = ref("邦文(日本語)");

//media変更に関係する処理群
const input_value = ref([""]);
const mediaChange = (e: any) => {
  console.log(e);
  switch (e) {
    case "雑誌論文":
      input_value.value = article.to_list();

      break;
  }
};

//著者入力に関わる処理群
const authorFirstNames = ref([""]);
const authorLastNames = ref([""]);
let author = {
  lastName: "",
  firstName: "",
};
const authorList = ref([author]);
const getList = () => {
  authorList.value = []; // リストをクリアしてから再構築

  for (let i = 0; i < authorNum.value; i++) {
    author = {
      lastName: authorLastNames.value[i],
      firstName: authorFirstNames.value[i],
    };
    authorList.value.push(author);
  }
};

//書誌情報入力にかかわる処理群
const input_data = ref([""]);
const bib_data: { [label: string]: string } = {};
const parsebib = () => {
  for (let i = 0; i < input_data.value.length; i++) {
    const item = input_data.value[i];
    const label = input_value.value[i];
    bib_data[label] = item;
    article.perse_data(authorList.value, input_data.value);
  }
  console.log(bib_data);
};
//入力された物に関わる処理群
</script>

<style></style>
