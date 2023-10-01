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
    <v-btn @click="handleButtonClick">書式事項を抽出</v-btn>
    <v-text-field
      v-model="authorNum"
      label="著者の人数を入力"
      type="number"
      max="20"
    ></v-text-field>
  </v-container>
</template>

<script setup>
const authorNum = ref();
const default_style = "日本心理学会執筆・投稿の手びき_2015年改訂版";
const handleButtonClick = () => {
  console.log(authorNum.value);
};
</script>

<style></style>
