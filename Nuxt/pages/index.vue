<template>
  <v-container>
    <p>参考文献リストの書式を選択</p>
    <v-select
      label="Select"
      :items="[
        'California',
        'Colorado',
        'Florida',
        'Georgia',
        'Texas',
        'Wyoming',
      ]"
    ></v-select>
    <v-btn>aaa</v-btn>
  </v-container>
</template>

<style>
select {
  -moz-appearance: menulist-button;
  -webkit-appearance: menulist-button;
  appearance: menulist-button;
}
</style>
