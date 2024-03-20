<template>
  <textarea
    class="inputFields"
    ,name=""
    id=""
    cols="80"
    rows="5"
    :placeholder="props.placeHolder"
  ></textarea>
</template>

<script lang="ts" setup>
import { defineProps, withDefaults } from "vue";
interface Props {
  placeHolder: string;
}
const props = withDefaults(defineProps<Props>(), { placeHolder: "" });
</script>

<style>
.inputFields {
  width: 80%;
  resize: none;
  padding: 10px;
  font-size: 16px;
  color: #666666;
  border: 2px solid #cccccc;
  border-radius: 6px;
}
</style>
