<template>
  <h1>Vuex Store</h1>
  <p>Cannot use layout that creates its own store and injects</p>



</template>

<script lang="ts">
import {defineComponent} from "vue";
import {useStore} from "@/store";



export default defineComponent({
  name: "VuexStore",
  setup() {
    const vStore = useStore()


    return { }
  }

})
</script>

<style lang="scss">
</style>
