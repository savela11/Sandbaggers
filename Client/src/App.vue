<template>
  <PageLoadingComponent v-show="isCurrentViewLoading"/>
  <component :is="this.$route.meta.layout || 'div'">
    <router-view/>
  </component>
</template>
<script lang="ts">
import {computed, defineAsyncComponent, defineComponent, reactive, ref, toRef} from 'vue'
import {store} from "@/store";
import PageLoadingComponent from "@/components/loaders/PageLoadingComponent.vue";
import router from "@/router";

export default defineComponent({
  name: 'App',
  components: {
    PageLoadingComponent
    // PageLoadingComponent: defineAsyncComponent(() => import("@/components/loaders/PageLoadingComponent.vue")),
    
  },
  setup(props, context) {
    let isCurrentViewLoading = computed(() => store.state.ui.CurrentView.isLoading)
    return {isCurrentViewLoading}
  }
})
</script>

<style lang="scss">

</style>
