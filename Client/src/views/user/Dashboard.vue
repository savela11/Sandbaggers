<script lang="ts">
import {defineAsyncComponent, defineComponent, reactive} from "vue";
import {useStore} from "@/store";
import DashboardService from "@/services/User/DashboardService";
import {UserVm} from "@/types/viewmodels/UserVm";

export default defineComponent({
  name: "Dashboard",
  components: {
    TestComponent: defineAsyncComponent(() => import("@/components/TestComponent.vue")),
  },
  setup(props: any) {
    const store = useStore();
    let data = reactive({
      users: [] as UserVm[],
    });

    const getData = async () => {
      try {
        // const res = await UserManagerService.AllUsers()
        const res = await DashboardService.DashboardData()
        // const res = await AuthService.allUsers()
        console.log(res)
        if (res.status === 200) {
          data.users = res.data;
          console.log(data)
        }

      } catch (e) {
        console.log(e)
      }
    }
    const logout = () => {
      store.dispatch("auth/logoutUser")


    }
    return {getData, logout, data}

  }
})
</script>

<template>
  <h1 class="text text--title">Dashboard</h1>
  <button @click="getData">Get the data</button>
  <h2 class="text text--secondary-title">Data Users</h2>
  <p class="text text--para"> this is the para graph font Lorem ipsum dolor sit amet, consectetur adipisicing elit. Alias deleniti, eaque eos fuga id laborum molestias vitae. Blanditiis culpa earum iste laboriosam laborum saepe voluptatem! Deleniti, molestiae, suscipit. Ipsum, nobis.</p>
  <div v-for="user in data.users" v-bind:key="user.id">
    {{ user.fullName }}
  </div>

  <TestComponent/>
</template>
<style lang="scss">

</style>
