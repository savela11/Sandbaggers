import {ActionContext} from "vuex";

export type UIState = {
    CurrentView: {
        isLoading: boolean
        name: string
    }
}


/* *** STATE *** */
const state: UIState = {
    CurrentView: {
        isLoading: true,
        name: ''
    }
}

/* *** GETTERS *** */
const getters = {}


/* *** MUTATIONS *** */
const mutations = {

    setCurrentViewLoading(state: UIState, payload: boolean) {
        state.CurrentView.isLoading = payload
    },
    setCurrentViewName(state: UIState, payload: string) {
        state.CurrentView.name = payload
    }
}

/* *** ACTIONS *** */
const actions = {
    async toggleCurrentViewLoading(context: ActionContext<UIState, any>, payload: boolean) {
        console.log('payload from ui store', payload)
        context.commit('setCurrentViewLoading', payload)
    },
    setCurrentViewName(context: ActionContext<UIState, any>, payload: string) {
        context.commit("setCurrentViewName", payload)
    }
}
export default {
    namespaced: true,
    state,
    getters,
    actions,
    mutations,

}

