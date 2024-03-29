// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  devtools: { enabled: true },
  css: ["bootstrap/dist/css/bootstrap.min.css"],
  runtimeConfig: {
    apiKey: "",
    apiUrl: "",
    public: {
      apiUrlBase: "",
      apiDevelopUrlBase: "",
      version: "",
    },
  },
});
