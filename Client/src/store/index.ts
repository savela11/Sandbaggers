import {createStore, useStore as baseUseStore, createLogger, Store,} from "vuex";
import createPersistedState from 'vuex-persistedstate';
import {InjectionKey} from "vue";

import SecureLS from "secure-ls";

const ls = new SecureLS({isCompression: false})

/* ***STORE MODULES*** */
import auth, {AuthState} from "@/store/auth";
import ui, {UIState} from "@/store/ui";
import navigation, {NavigationState} from "@/store/navigation";

export type RootState = {
    auth: AuthState
    ui: UIState
    navigation: NavigationState
}


const debug = import.meta.env.NODE_ENV !== 'production'
const plugins = debug ? [createLogger({})] : []

// plugins.push(createPersistedState({ storage: window.sessionStorage }));

plugins.push(
    createPersistedState({
        key: 'Sandbagger',
        // paths: ['auth'],
        storage: {
            getItem: (key): string => {
                return ls.get(key)
            },
            setItem: (key, value): void => {
                ls.set(key, value)
            },
            removeItem: (key): void => {
                ls.remove(key)
            },
        },
    }),
);
// define injection key
export const key: InjectionKey<Store<RootState>> = Symbol()

export const store = createStore<RootState>({
    // state: {} as RootState,
    // plugins,
    modules: {
        auth,
        ui,
        navigation
    },
})

export function useStore() {
    return baseUseStore(key)
}
