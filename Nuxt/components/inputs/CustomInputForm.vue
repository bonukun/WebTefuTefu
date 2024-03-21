<template>
  <textarea
    class="inputFields"
    ,name=""
    id=""
    cols="80"
    rows="5"
    :placeholder="props.placeHolder"
    @input="onchange"
  ></textarea>
</template>

<script lang="ts" setup>
import { defineProps, withDefaults } from "vue";
interface Props {
  placeHolder: string;
}
const props = withDefaults(defineProps<Props>(), { placeHolder: "" });

type Emits = {
  (event: "change", value: string): void;
};
const emits = defineEmits<Emits>();
const onchange = (event: any) => {
  console.log("発火");
  emits("change", event.target.value);
};
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
