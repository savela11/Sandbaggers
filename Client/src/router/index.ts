import {createRouter, createWebHistory, RouteRecordRaw, NavigationGuardNext, RouteLocationNormalized, RouteLocation, RouteRecordName} from 'vue-router'
import {defineAsyncComponent} from "vue";
import DefaultLayout from '../layouts/DefaultLayout.vue'


import userRoutes from "@/router/userRoutes";
import testRoutes from "@/router/testRoutes";
import adminRoutes from "@/router/adminRoutes";
import {store} from "@/store";

function generateRoute(route: string) {
    return () => import(`../views/${route}.vue`)
}

function setLayout(layout: string) {
    // LatestBox: defineAsyncComponent(() => import('@/components/LatestBox.vue'))
    // return () => import(`../layouts/${layout}.vue`)
    return defineAsyncComponent(() => import(`../layouts/${layout}.vue`))
}

function guardRoute(to: RouteLocation, from: RouteLocation, next: NavigationGuardNext): any {
    console.log(to)
    console.log(from)
    let authenticated = false;
    if (authenticated && to.name === "Login") {
        next("/Dashboard");

    } else if (!authenticated) {
        if (to.name === "Login") {
            next()
        } else {
            next("/Login")
        }
    }

}

const routes: Array<RouteRecordRaw> = [
    ...userRoutes,
    ...testRoutes,
    ...adminRoutes,

    {
        path: "/",
        name: 'Default',
        component: generateRoute('Login'),
        meta: {
            layout: DefaultLayout
        },
    },
    {
        path: "/:catchAll(.*)",
        name: 'NotFound',
        component: generateRoute('NotFound'),
        beforeEnter: guardRoute,
        meta: {
            layout: DefaultLayout
        },
    },

    {
        path: '/Login',
        name: 'Login',
        beforeEnter: guardRoute,
        component: generateRoute('Login'),
        meta: {
            title: 'Login',
            layout: DefaultLayout
        }
    },


]
const router = createRouter({
    history: createWebHistory(),
    routes,
})


router.beforeEach((to: RouteLocationNormalized, from: RouteLocationNormalized, next: NavigationGuardNext) => {
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
        store.dispatch("ui/toggleCurrentViewLoading", false).then(() => {
        })
        if (to.name !== "Login") {
            return next("/Login")
        } else {
            return next()
        }
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
