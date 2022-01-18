<template>
  <h1>This is the testComponent</h1>
</template>

<script lang="ts">
import {defineComponent} from "vue";

export default defineComponent({
  name: "TestComponent",
  setup(props: any) {

    return {}

  }
})
</script>

<style lang="scss" scoped>
h1 {
  color: red;
}
</style>
