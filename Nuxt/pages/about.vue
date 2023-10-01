<template>
  <v-container>
    <h2>{{ title }}</h2>
    <v-btn @click="pushButton"> PUSH! </v-btn>
  </v-container>
</template>
<script>
export default {
  data: () => ({
    title: "This is the test page.",
  }),
  methods: {
    pushButton() {
      this.title = "PUSHED!";
    },
  },
};
</script>
