import {ActionContext} from "vuex";
import SecureLS from "secure-ls";
import router from "@/router";
import {LoggedInUserVm} from "@/types/viewmodels/AuthViewModel";

export type AuthState = {
    CurrentUser: LoggedInUserVm | null
    IsLoggedIn: boolean
}
// const ls = new SecureLS({isCompression: false})

// let localSandbagger = ls.get('Sandbagger')
let localSandbagger = sessionStorage.getItem('Sandbagger');

let user: LoggedInUserVm | null = null
if (localSandbagger) {
    // user = JSON.parse(localSandbagger).auth.CurrentUser as LoggedInUserVm
    user = JSON.parse(localSandbagger) as LoggedInUserVm
}


let loggedInStatus = !!user;
/* *** STATE *** */
const state: AuthState = {
    CurrentUser: user,
    IsLoggedIn: loggedInStatus
}

/* *** GETTERS *** */
const getters = {}


/* *** MUTATIONS *** */
const mutations = {
    loginUser(state: AuthState, payload: LoggedInUserVm) {
        sessionStorage.setItem('Sandbagger', JSON.stringify(payload));
        state.CurrentUser = payload
        state.IsLoggedIn = true;
    },

    logoutUser(state: AuthState) {
        sessionStorage.removeItem('Sandbagger');
        state.CurrentUser = null
        state.IsLoggedIn = false;
        // ls.remove('Sandbagger')
    }

}

/* *** ACTIONS *** */
const actions = {
    async loginUser(context: ActionContext<AuthState, any>, payload: LoggedInUserVm) {
        await context.commit('loginUser', payload)
        await router.push('/Dashboard')

    },
    async logoutUser(context: ActionContext<AuthState, any>) {
        await context.commit('logoutUser')
        await router.push('/Login');

    }
}
export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations,

}

