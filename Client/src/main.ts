import {createApp} from 'vue'
import App from './App.vue'
import router from './router/index'
import {store, key} from "@/store";
import '@/assets/styles/main.scss'


createApp(App).use(store, key).use(router).mount('#app')
