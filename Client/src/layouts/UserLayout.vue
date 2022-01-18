<template>
  <div class="layout-container">
      
    <ShowCurrentLayoutName :layout="'User'"/>
    <header class="landmark landmark--header">
      <div class="container container--header">
        <p>Header</p>
      </div>
    </header>

    <main :class="['landmark landmark--main', 'landmark--main--' + currentViewName]">
      <slot/>
    </main>

    <footer class="landmark landmark--footer">
      <NavBar/>
    </footer>
  </div>
</template>

<script lang="ts">
import {computed, defineAsyncComponent, defineComponent} from "vue";
import {store} from "@/store";
import NavBar from "@/layouts/components/NavBar.vue";
import ShowCurrentLayoutName from "@/layouts/components/ShowCurrentLayoutName.vue";

export default defineComponent({
  name: "UserLayout",
  components: {
    // NavBar: defineAsyncComponent(() => import("./components/NavBar.vue")),
    NavBar,
    ShowCurrentLayoutName
  },

  setup(props: any, context) {

    const currentViewName = computed(() => store.state.ui.CurrentView.name);


    return {currentViewName}

  }
})
</script>

<style lang="scss" scoped>
.container {
  &--header {
  }

  &--main {
  }
}


</style>
