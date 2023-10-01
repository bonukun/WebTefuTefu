import { createVuetify } from "vuetify";
import * as components from "vuetify/components";
import { aliases, mdi } from "vuetify/iconsets/mdi";
import "@mdi/font/css/materialdesignicons.css";

export default defineNuxtPlugin((nuxtApp) => {
  const vuetify = createVuetify({
    components,
    defaultAssets: {
      font: true,
      icons: "md",
    },
    icons: {
      iconfont: "md",
    },
  });

  nuxtApp.vueApp.use(vuetify);
});
