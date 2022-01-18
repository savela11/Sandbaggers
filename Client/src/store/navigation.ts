import {ActionContext} from "vuex";
import {MenuLink} from "@/types/vuexStore/navigation";


export type NavigationState = {
    NavBar: {
        isMenuShowing: boolean;
        links: Array<MenuLink>
        isMenuAnimating: ('hide-nav-menu' | 'show-nav-menu')
        admin: {
            links: Array<MenuLink>
        }
    }
}


/* *** STATE *** */
const state: NavigationState = {
    NavBar: {
        isMenuAnimating: 'hide-nav-menu',
        isMenuShowing: false,
        links: [
            {name: 'Dashboard', url: '/dashboard'},
            {name: 'Bets', url: '/bets'},
            // {name: 'VuexStoreTest', url: '/VuexStore'},
        ],
        admin: {
            links: [
                {name: 'Admin', url: '/admin'},
            ]
        }
    }
}

/* *** GETTERS *** */
const getters = {}


/* *** MUTATIONS *** */
const mutations = {
    setNavBarMenu(state: NavigationState, status: boolean) {
        let isAnimating: 'hide-nav-menu' | 'show-nav-menu';
        status ? isAnimating = 'show-nav-menu' : isAnimating = 'hide-nav-menu';

        if (status) {
            state.NavBar.isMenuAnimating = isAnimating
            state.NavBar.isMenuShowing = status
        } else {
            state.NavBar.isMenuAnimating = isAnimating
            setTimeout(() => {
                state.NavBar.isMenuShowing = status
            }, 300)
        }
        // state.NavBar.isMenuShowing = payload
    }

}

/* *** ACTIONS *** */
const actions = {
    async toggleNavBarMenu(context: ActionContext<NavigationState, any>, status: boolean) {
        context.commit('setNavBarMenu', status)

    }
}
export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations,

}

