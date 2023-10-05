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
      label="参考文献の形態を選択"
      :items="['雑誌論文', '図書', 'ウェブサイト']"
      @update:model-value="mediaChange"
      variant="underlined"
      return-object
    ></v-select>
    <v-textarea label="BibTeXペースト欄"></v-textarea>
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
      <v-text-field :label="`第${n}著者名を入力`" variant="underlined">
      </v-text-field>
    </v-row>
    <v-row v-for="n in input_value" :key="n">
      <v-text-field :label="`${n}を入力`"></v-text-field>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
import { Article } from "~/types/jpa_style/article";
const default_style = "日本心理学会執筆・投稿の手びき_2015年改訂版";

const handleButtonClick = () => {
  const article = new Article();
  console.log(article.title);
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

//media変更に関係する処理群
const input_value = ref([""]);
const mediaChange = (e: any) => {
  console.log(e);
  switch (e) {
    case "雑誌論文":
      const article = new Article();
      input_value.value = article.to_list();

      break;
  }
  console.log(input_value);
};
</script>

<style></style>
