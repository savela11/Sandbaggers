import axios, {AxiosError, AxiosRequestConfig, AxiosResponse} from 'axios'

import SecureLS from 'secure-ls'

const url = 'https://localhost:5001'
const ls = new SecureLS({isCompression: false})
import {store} from '@/store'
import {LoggedInUserVm} from "@/types/models/ViewModels/AuthViewModel";

const apiClient = axios.create({
    baseURL: import.meta.env.MODE === "production" ? url : '/api'

})

apiClient.interceptors.request.use(
    (config: AxiosRequestConfig) => {
        config.withCredentials = true
        axios.defaults.headers.common['Authorization'] = ''
        delete axios.defaults.headers.common['Authorization']
        // const storage = JSON.parse(ls.get('Sandbagger'))
        let storageOne = sessionStorage.getItem("Sandbagger") as string || null;
        let currentUser = null as LoggedInUserVm | null;
        if (storageOne) {
            currentUser = JSON.parse(storageOne);
            let token = null
            if (currentUser) {
                token = currentUser.token;
                if (token) {
                    config.headers.common.Authorization = `Bearer ${token}`
                }
            }
        }

        // if (storage.auth.CurrentUser != null) {
        //     const token = storage.auth.CurrentUser.token
        //     if (token) {
        //         config.headers.common.Authorization = `Bearer ${token}`
        //     }
        // }
        if (import.meta.env.MODE !== 'production') {
            console.log('Request: ', config)
        }
        return config
    },
    (error: AxiosError) => {
        console.log('error', error)
        return Promise.reject(error)
    }
)

apiClient.interceptors.response.use(
    (response: AxiosResponse) => {
        if (import.meta.env.MODE !== 'production') {
            console.log('Response: ', response)
        }

        return response
    },
    async (error: AxiosError) => {
        if (error && error.response) {
            if (error.response.status === 401 || error.response.statusText === 'Unauthorized' || error.response.status === 500) {
                await store.dispatch('auth/logoutUser')
            }
        }

        // console.log("Response Error", error.response);

        if (error && error.message) {
            if (error.message === 'Network Error') {
                await store.dispatch('auth/logoutUser')
                console.log('Error!', error.message)
            }
        }

        return Promise.reject(error.response)
    }
)

export default apiClient
