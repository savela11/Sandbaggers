import {defineAsyncComponent} from "vue";
import UserLayout from '../layouts/UserLayout.vue'

function generateRoute(route: string) {
    return () => import(`../views/user/${route}.vue`)
}

function setLayout(layout: string) {
    return defineAsyncComponent(() => import(`../layouts/${layout}.vue`))
}

//
// function guardRoute(to: RouteLocationNormalized, from: RouteLocationNormalized, next: NavigationGuardNext): any {
//     let authenticated = false;
//     if (store.state.auth.IsLoggedIn) {
//         authenticated = true;
//     }
//
//     if (authenticated) {
//         next();
//
//     } else {
//         store.dispatch("auth/logoutUser").then();
//         // next("/login");
//     }
// }

const routes = [
    {
        path: "/dashboard",
        name: "Dashboard",
        component: generateRoute('Dashboard'),
        // beforeEnter: UserAuthenticated,
        meta: {
            title: 'Dashboard',
            layout: UserLayout,
            role: 'User',
        }
    }
]


export default routes
