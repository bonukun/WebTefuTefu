// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  devtools: { enabled: true },
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
