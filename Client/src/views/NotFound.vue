<template>
  <h1>Not Found</h1>
  <div
    class="background"
    :style="{ backgroundImage: 'url(' + imgUrl + ')' }"
  ></div>
  <!--  <div class="background" :style="{ backgroundImage: 'url('+'src/assets/images/Login-BG.jpg'+')' }" ></div>-->
  <!--  <div class="background" :style="{ backgroundImage: 'url('+'src/assets/images/' + img +')' }" ></div>-->
</template>

<script lang="ts">
import {
  computed,
  defineAsyncComponent,
  defineComponent,
  onMounted,
  reactive,
  ref,
} from "vue";

export default defineComponent({
  name: "NotFound",
  components: {},
  setup(props: any) {
    const imgUrl = new URL("../assets/images/Login-BG.jpg", import.meta.url);
    console.log(imgUrl.pathname);
    console.log(import.meta.url);
    const img = "Login-BG.jpg";
    return { imgUrl, img };
  },
});
</script>

<style lang="scss" scoped>
.background {
  height: 400px;
  background-size: cover;
}
</style>
