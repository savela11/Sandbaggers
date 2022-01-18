<template>
  <header>
    <div class="container container--header">
      <h2>Admin Layout</h2>
    </div>
  </header>


  <main>
    <div class="container container--main">
      <slot/>
    </div>
  </main>

  <footer>
    <NavBar />
  </footer>

</template>

<script lang="ts">
import {defineAsyncComponent, defineComponent, onMounted, ref,} from "vue";
import {useStore} from "vuex";

export default defineComponent({
  name: "Admin Layout",
  components: {

    NavBar: defineAsyncComponent(() => import("./components/NavBar.vue")),
  },
  props: {

  },
  setup(props: any, context) {

    console.log(props)
    

    return {}

  }
})
</script>

<style lang="scss" scoped>
.container {
  padding: 1rem;

  &--header {
  }

  &--main {
  }
}


</style>
