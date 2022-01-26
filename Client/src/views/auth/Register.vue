<script lang="ts">
import {
  defineAsyncComponent,
  defineComponent,
  reactive,
} from "vue";
import {RegisterUserDto} from "@/types/models/DTO/AuthDto";

export default defineComponent({
  name: "Register",
  components: {
    BaseInput: defineAsyncComponent(
        () => import("@/components/forms/BaseInput.vue")
    ),
  },
  setup(props: any) {
    let registerForm: RegisterUserDto = reactive({
      username: "",
      password: "",
      confirmPassword: "",
      email: "",
      firstName: "",
      lastName: "",
      registrationCode: '',
      loginAfterRegister: false,
    });



    return {};
  },
});
</script>

<template>
  <h1>Register</h1>

</template>

<style lang="scss" scoped>
</style>
