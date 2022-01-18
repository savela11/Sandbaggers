<template>
  <div class="current-layout-name" v-if="!isDev" :class="{'showing': isShowing}">
    <div class="section">
      <p class="text text--layout-name">{{ layout }} Layout</p>
    </div>
    <div class="section">
      <button class="btn btn--close" @click.prevent.stop="toggleShowLayout">{{ isShowing ? 'Close' : 'Open' }}</button>
    </div>
  </div>
</template>

<script lang="ts">
import {computed, defineComponent, ref} from "vue";

export default defineComponent({
  name: "ShowCurrentLayoutName",
  props: {
    layout: {
      type: String,
      required: true
    }
  },
  setup(props: any) {

    let isShowing = ref(false);
    let isDev = computed(() => {
      const location = window.location;
      return location.port === "8080";
    })

    const toggleShowLayout = () => {
      isShowing.value = !isShowing.value;
      // isShowing.value ? className.value = 'showing' : className.value = 'hidden'
    };
    return {isShowing, toggleShowLayout, isDev}


  }
})
</script>

<style lang="scss" scoped>
.current-layout-name {
  background-color: blue;
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  transform: translateY(-100%);
  z-index: 3;

  &.showing {
    transform: translateY(0);
  }

  .text {
    color: white;

    &--layout-name {
    }
  }

  .btn {
    border: none;
    font-size: 1.2rem;
    padding: 0;
    font-weight: 400;

    &--close {
      position: absolute;
      right: 5%;
      bottom: -100%;
      background-color: white;
    }
  }

  .section {
    position: relative;
  }
}
</style>
