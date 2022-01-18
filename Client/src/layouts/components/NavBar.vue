<script lang="ts">
import {computed, defineAsyncComponent, defineComponent, onMounted, ref, toRef, toRefs,} from "vue";
import AuthService from "@/services/Auth/AuthService";
import {store, useStore} from "@/store";

export default defineComponent({
  name: "NavBar",
  components: {},
  setup(props: any, {emit}) {
    const store = useStore();
    let CurrentUserRoles = computed(() => store.state.auth.CurrentUser?.roles) || null

    async function logout(val: boolean) {
      console.log('this is in the navBar', val)
      try {

        const res = await AuthService.logout()
        console.log(res)
        await store.dispatch('auth/logoutUser')

      } catch (e) {
        console.log(e)
      }
    }

    let {isMenuShowing, links, isMenuAnimating, admin} = toRefs(store.state.navigation.NavBar)
    const adminLinks = admin.value.links;
    const toggleMenu = (status: boolean) => {
      store.dispatch('navigation/toggleNavBarMenu', status)
    }
    return {logout, CurrentUserRoles, isMenuShowing, isMenuAnimating, toggleMenu, links, adminLinks}

  }
})
</script>
<template>
  <div class="nav-bar">
    <div class="nav-bar__bg" v-show="isMenuShowing" @click.prevent.stop="toggleMenu(false)"></div>
    <div class="nav-bar__container" :class="isMenuShowing ? 'hide-container' : 'show-container'">
      <div class="nav-bar__menu-btn-container">
        <button class="nav-bar__btn nav-bar__btn--menu-btn" @click.prevent.stop="toggleMenu(true)">
          <svg viewBox="0 0 26 26" fill="none" xmlns="http://www.w3.org/2000/svg">
            <g clip-path="url(#clip0)">
              <path
                  d="M0.888885 8.38892H8.02102V1.40363H0.888885V8.38892ZM9.82282 8.38892H16.955V1.40363H9.82282V8.38892ZM18.7192 8.38892H25.8889V1.40363H18.7192V8.38892ZM0.888885 17.1389H8.02102V10.1536H0.888885V17.1389ZM9.82282 17.1389H16.955V10.1536H9.82282V17.1389ZM18.7192 17.1389H25.8889V10.1536H18.7192V17.1389ZM0.888885 25.8889H8.02102V18.8669H0.888885V25.8889ZM9.82282 25.8889H16.955V18.8669H9.82282V25.8889ZM18.7192 25.8889H25.8889V18.8669H18.7192V25.8889Z"
                  fill="#051D3A"/>
            </g>
            <defs>
              <clipPath id="clip0">
                <rect width="25" height="25" fill="white" transform="translate(0.888885 0.888916)"/>
              </clipPath>
            </defs>
          </svg>
        </button>
      </div>
    </div>

    <div class="nav-menu" v-show="isMenuShowing" :class="isMenuAnimating">
      <ul v-if="CurrentUserRoles && CurrentUserRoles.includes('User')" class="nav-menu__container nav-menu__container--links">
        <li class="nav-menu__link" v-for="(link,index) in links" :key="index">
          <router-link :to="link.url">
            {{ link.name }}
          </router-link>
        </li>
      </ul>
      <ul v-if="CurrentUserRoles && CurrentUserRoles.includes('Admin')" class="nav-menu__container nav-menu__container--links">
        <li class="nav-menu__link" v-for="(link,index) in adminLinks" :key="index">
          <router-link :to="link.url">
            {{ link.name }}
          </router-link>
        </li>
      </ul>
      <div class="nav-menu__container nav-menu__container--additional">
        <slot name="nav-menu-additional"/>
        <button @click.prevent.stop="logout">Logout</button>
      </div>
    </div>
    <!--    <NavMenu @logout="logout" v-bind="{CurrentUserRoles, isMenuShowing, isMenuAnimating, links, adminLinks}"/>-->
  </div>
</template>


<style lang="scss" scoped>
@use "../../assets/styles/globals" as g;

.nav-bar {
  z-index: map-get(g.$zIndex, NavBar);
  position: fixed;
  bottom: 0;
  left: 0;
  right: 0;
  display: flex;

  &__btn {
    border: none;

    &--menu-btn {
      padding: .2rem;
      @include g.mobile {
       padding: .5rem; 
      }
    }

    svg {
      height: 25px;
      width: 25px;

      @include g.mobile {
        height: 30px;
        width: 30px;
      }
    }
  }

  &__bg {
    position: fixed;
    z-index: 1;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background-color: black;
    opacity: .25;
  }

  &__container {
    position: relative;
    background-color: white;
    z-index: 3;
    height: 30px;
    flex: auto;
    box-shadow: 0 -3px 3px rgba(0, 0, 0, .25);
    padding: .5rem;

    &.show-container {
      animation: show-container .3s linear forwards;
    }

    &.hide-container {
      animation: hide-container .3s linear forwards;
    }
  }

  &__menu-btn-container {
    display: flex;
    justify-content: center;
    align-items: center;
    border-radius: 100px;
    box-shadow: 0 2px 8px rgba(0, 0, 0, .25);
    padding: .8rem;
    background-color: white;
    position: absolute;
    top: 0;
    left: 50%;
    transform: translate(-50%, -30px);
    @include g.mobile {
      transform: translate(-50%, -35px);
    }
  }
}

@keyframes show-container {
  0% {
    //opacity: 0;
    transform: translateY(200%);
  }
  100% {
    //opacity: 1;
    transform: translateY(0);
  }
}

@keyframes hide-container {
  0% {
    transform: translateY(0);
  }
  100% {
    transform: translateY(200%);
  }
}

.nav-menu {
  z-index: 2;
  position: fixed;
  bottom: 0;
  left: 0;
  right: 0;
  background-color: white;
  transform: translateY(100%);
  padding: .3rem;
  min-height: 350px;
  display: flex;
  flex-direction: column;

  &.show-nav-menu {
    animation: show-nav-menu .3s linear forwards;
  }

  &.hide-nav-menu {
    animation: hide-nav-menu .3s linear forwards;
  }

  &__container {
    padding: .5rem;

    &--links {
      padding: 0;
      margin: 0;
      list-style-type: none;
      flex: 1 1 auto;
      border: 1px solid red;
      display: flex;
      flex-wrap: wrap;

      li {
        flex: 0 1 33%;
        display: flex;
        justify-content: center;
        padding: .5rem;
      }

      a {
      }
    }

    &--additional {
      flex: 0 0 auto;
      border: 1px solid blue;
    }
  }
}

@keyframes show-nav-menu {
  0% {
    //opacity: 0;
    transform: translateY(100%);
  }
  100% {
    //opacity: 1;
    transform: translateY(0);
  }
}

@keyframes hide-nav-menu {
  0% {
    transform: translateY(0);
  }
  100% {
    transform: translateY(100%);
  }
}
</style>
