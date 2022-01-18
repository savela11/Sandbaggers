<script lang="ts">
import {defineAsyncComponent, defineComponent, reactive} from "vue";

export default defineComponent({
  name: "Bets",
  components: {
    TestComponent: defineAsyncComponent(() => import("@/components/TestComponent.vue")),
  },
  setup(props: any) {
    let data = reactive({
      bets: [] as [],
    });

    return {}

  }
})
</script>

<template>
  <h1>Bets</h1>
  
</template>

<style lang="scss" scoped>

</style>
