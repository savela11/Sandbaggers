<template>
  <div class="layout-container">
    
  <main :class="['landmark landmark--main', 'landmark--main--' + currentViewName]">
    <slot />
  </main>

  </div>
</template>

<script lang="ts">
import {computed, defineComponent} from 'vue'
import {store} from "@/store";


export default defineComponent({
  name: 'App',
  components: {},
  setup() {
    const currentViewName = computed(() => store.state.ui.CurrentView.name);
    return {
      currentViewName
    }
  }
})
</script>

<style lang="scss" scoped>

</style>
