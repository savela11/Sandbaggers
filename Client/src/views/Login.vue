<script lang="ts">
import {
  computed,
  defineAsyncComponent,
  defineComponent,
  onMounted,
  reactive,
  ref,
} from "vue";
import AuthService from "@/services/Auth/AuthService";
import { key, useStore } from "@/store";
import { LoginUserDto } from "@/types/models/DTO/AuthDto";
import axios from "axios";
// import img from '@/assets/images/Login-BG.jpg'

export default defineComponent({
  name: "Login",
  components: {
    BaseInput: defineAsyncComponent(
      () => import("@/components/forms/BaseInput.vue")
    ),
  },
  setup(props: any) {
    const store = useStore();
    const currentUser = computed(() => store.state.auth.CurrentUser);

    // const bgImage = { backgroundImage: "url(" + img + ")" }
    const bgImage = { backgroundImage: "url(src/assets/images/Login-BG.jpg)" };
    let loginForm: LoginUserDto = reactive({
      username: "",
      password: "",
    });

    const Login = async () => {
      try {
        const res = await AuthService.loginUser(loginForm);
        if (res.status === 200) {
          store.dispatch("auth/loginUser", res.data).then();
        }
        console.log(res);
      } catch (e) {
        console.log(e);
      }
    };

    let message = ref("");
    const testData = async () => {
      try {
        const res = await axios.get("/api/test/get");
        console.log(`RES: ${res.data.message} from Login View`);
        message.value = res.data.message;
      } catch (e) {
        console.log(e);
      }
    };
    onMounted(() => {
      testData();
    });

    return { loginForm, bgImage, Login, currentUser, message };
  },
});
</script>

<template>
  <div class="container container--login">
    <div class="section section--top">
      <div class="background-image" :style="bgImage"></div>
      <h1 class="text text-title">Login</h1>
    </div>
    <p>here is the message: {{ message }}</p>
    <div class="section section--bottom">
      <div class="container container--back"></div>
      <div class="container container--front">
        <form class="form">
          <div class="field">
            <BaseInput
              v-bind="{ label: 'Username', color: 'primary' }"
              v-model="loginForm.username"
            />
          </div>
          <div class="field">
            <BaseInput
              v-bind="{
                label: 'Password',
                color: 'primary',
                inputType: 'password',
              }"
              v-model="loginForm.password"
            />
          </div>
          <div class="field">
            <button class="btn btn--submit" @click.prevent.stop="Login">
              Login
            </button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.container--login {
  position: relative;

  .text {
    &-title {
      margin: 0;
    }
  }

  .background-image {
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    z-index: -1;
    background-size: cover;
    background-repeat: no-repeat;
  }

  .section {
    flex: auto;
    min-height: 50%;

    // &--top {
    // }

    &--bottom {
      background-color: white;
      border-radius: 2px;
    }
  }
}
</style>
