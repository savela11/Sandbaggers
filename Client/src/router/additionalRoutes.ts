import UIHelper from '@/utility/UIHelper'
import { Route, NavigationGuardNext } from 'vue-router'
import store from '../store/vuex'
import AuthLayout from '@/layouts/authLayouts/AuthLayout.vue'
import AuthLayoutNoNavBar from '@/layouts/authLayouts/AuthLayoutNoNavBar.vue'
import AuthLayoutNoHeader from '@/layouts/authLayouts/AuthLayoutNoHeader.vue'
import AuthLayoutNoHeaderAlt from '@/layouts/authLayouts/AuthLayoutNoHeader-Alt.vue'
import AuthLayoutNoBars from '@/layouts/authLayouts/AuthLayoutNoBars.vue'


function loadView(view: string): () => Promise<typeof import('*.vue')> {
    return (): Promise<typeof import('*.vue')> => import(/* webpackChunkName: "view-[request]" */ `@/views/additional/${view}.vue`)
}


function guardRoute(to: Route, from: Route, next: NavigationGuardNext): any {
    let authenticated = false
    UIHelper.PageLoading(true)
    if (store.state.authStore.isLoggedIn && store.state.authStore.currentUser && to.meta.role) {
        const roles = store.state.authStore.currentUser.roles
        if (roles.includes(to.meta.role) || roles.includes("Admin")) {
            authenticated = true
        }
    }


    // const headerTitle = "";
    if (to.meta.backBtn) {
        store.dispatch('navigationStore/_setBackBtnShowingStatus', true).then()
    } else {
        store.dispatch('navigationStore/_setBackBtnShowingStatus', false).then()
    }
    if (authenticated) {
        next()
        UIHelper.PageLoading(false)


    } else {
        // store.dispatch('authStore/Logout').then()
        // store.dispatch('navigationStore/_setBackBtnShowingStatus', false).then()
        UIHelper.PageLoading(false)
        next('/dashboard')
    }
}

export default [

    {
        path: '/additional/PowerRankings',
        name: 'PowerRankings-additional',
        beforeEnter: guardRoute,
        component: loadView('powerRanking/PowerRankings'),
        meta: {
            layout: AuthLayoutNoHeaderAlt,
            role: 'MillerTime',
        }
    },
    {
        path: '/additional/PowerRankings/Create',
        name: 'CreatePowerRanking',
        beforeEnter: guardRoute,
        component: loadView('powerRanking/CreatePowerRanking'),
        meta: {
            layout: AuthLayoutNoHeaderAlt,
            role: 'MillerTime',
        }
    }
]


