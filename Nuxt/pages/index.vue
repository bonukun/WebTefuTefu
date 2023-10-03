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
      variant="underlined"
    ></v-select>
    <v-textarea label="BibTeXペースト欄"></v-textarea>
    <v-btn @click="handleButtonClick">BibTeXから書式事項を抽出</v-btn>
    <v-text-field
      v-model="authorNum"
      label="著者の人数を入力"
      type="number"
      @input="authorNum_limit"
      max="20"
      min="0"
    ></v-text-field>
    <v-row v-for="n in parseInt(authorNum.toString())" :key="n">
      <v-text-field :label="`第${n}著者名を入力`" variant="underlined">
      </v-text-field>
    </v-row>
  </v-container>
</template>

<script setup lang="ts">
const default_style = "日本心理学会執筆・投稿の手びき_2015年改訂版";

const handleButtonClick = () => {
  console.log(authorNum.valueOf);
};

const authorNum = ref(0);

const authorNum_limit = () => {
  console.log(authorNum.value);
  if (authorNum.value > 20) {
    authorNum.value = 20;
  }
};
</script>

<style></style>
