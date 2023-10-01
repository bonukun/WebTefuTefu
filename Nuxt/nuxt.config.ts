// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  devtools: { enabled: true },
  css: ["vuetify/lib/styles/main.sass"],
  build: {
    transpile: ["vuetify"],
  },
  plugins: [{ src: "~/plugins/vuetify.js" }],
  vite: {
    define: {
      "process.env.DEBUG": false,
    },
    // for HMR
    server: {
      watch: {
        usePolling: true,
      },
    },
  },
});
