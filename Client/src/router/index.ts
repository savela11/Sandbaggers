import {createRouter, createWebHistory, RouteRecordRaw, NavigationGuardNext, RouteLocationNormalized, RouteLocation, RouteRecordName} from 'vue-router'
import {defineAsyncComponent} from "vue";
import DefaultLayout from '../layouts/DefaultLayout.vue'


import userRoutes from "@/router/userRoutes";
import testRoutes from "@/router/testRoutes";
import adminRoutes from "@/router/adminRoutes";
import {store} from "@/store";
import authRoutes from "@/router/authRoutes";

function generateRoute(route: string) {
    return () => import(`../views/${route}.vue`)
}


const routes: Array<RouteRecordRaw> = [
    ...authRoutes,
    ...userRoutes,
    ...testRoutes,
    ...adminRoutes,

    {
        path: "/",
        name: 'Default',
        component: () => import("../views/auth/Login.vue"),
        meta: {
            layout: DefaultLayout,
            title: 'Login'
        },
    },
    {
        path: "/:catchAll(.*)",
        name: 'NotFound',
        component: generateRoute('NotFound'),
        meta: {
            layout: DefaultLayout,
            title: 'Not Found'
        },
    },


]
routes.forEach((route) => {
    console.log(route)
    if (route.meta!.role) {
        Object.assign(route, {meta: {...route.meta, requiresAuth: true}})
    } else {
        Object.assign(route, {meta: {...route.meta, requiresAuth: false}})
    }
})




const router = createRouter({
    history: createWebHistory(),
    routes,
})


router.beforeEach((to: RouteLocationNormalized, from: RouteLocationNormalized, next: NavigationGuardNext) => {

    if (to.meta.requiresAuth === false) {
        store.dispatch("ui/toggleCurrentViewLoading", false).then(() => {
        })
        return next()
    }


    const authStore = store.state.auth;

    let userHasRequiredRole: boolean | unknown = false;
    let isLoggedIn = authStore.IsLoggedIn
    let currentUser = authStore.CurrentUser

    const requiredRole: string | unknown = to.meta.role;

    if (typeof requiredRole === "string") {
        userHasRequiredRole = currentUser?.roles.includes(requiredRole);
        console.log(`Does User have required ${requiredRole} Role: ${currentUser?.roles.includes(requiredRole)}`)
    }


    if (isLoggedIn) {
        store.dispatch("ui/toggleCurrentViewLoading", true).then(() => {
        })
        if (userHasRequiredRole) {
            if (to.name === "Login") {
                return next("/Dashboard")
            } else {
                return next()
            }
        } else {
            store.dispatch('auth/logoutUser').then(() => {
                console.log(`Logging out user!!!`)
            })
        }

    } else {
        return next("/Login")
        // if (to.name !== "Login") {
        //     return next("/Login")
        // } else {
        //     return next()
        // }
    }

})
router.afterEach((to: RouteLocationNormalized, from: RouteLocationNormalized) => {
    let title = "Sandbaggers";
    if (to.meta.title) {
        title = to.meta.title as string;
    }

    store.dispatch("ui/setCurrentViewName", title.toLowerCase()).then(() => {
    })

    document.title = title

    if (to.name !== "Login") {
        setTimeout(() => {
            store.dispatch("ui/toggleCurrentViewLoading", false).then(() => {
                window.scrollTo(0, 0)
            })
        }, 2000)
    }
})
export default router
