<template>
  <h1>Not Found</h1>
  <p>Redirecting to Dashboard in {{timer}} seconds.</p>
  <div
    class="background"
    :style="{ backgroundImage: 'url(' + imgUrl + ')' }"
  ></div>
  <!--  <div class="background" :style="{ backgroundImage: 'url('+'src/assets/images/Login-BG.jpg'+')' }" ></div>-->
  <!--  <div class="background" :style="{ backgroundImage: 'url('+'src/assets/images/' + img +')' }" ></div>-->
</template>

<script lang="ts">
import {
  defineComponent,
  onMounted,
} from "vue";
import router from "@/router";

export default defineComponent({
  name: "NotFound",
  components: {},
  setup(props: any) {
    const imgUrl = new URL("../assets/images/Login-BG.jpg", import.meta.url);
    console.log(imgUrl.pathname);
    console.log(import.meta.url);
    const img = "Login-BG.jpg";
    let timer = 5
    onMounted(() => {
      console.log("redirecting");
      setTimeout(() => {
        router.push("/Dashboard")
      }, timer * 1000);
    });
    return { imgUrl, img, timer };
  },
});
</script>

<style lang="scss" scoped>
.background {
  height: 400px;
  background-size: cover;
}
</style>
