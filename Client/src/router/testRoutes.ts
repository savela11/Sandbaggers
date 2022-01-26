import {defineAsyncComponent} from "vue";

const viewFolder = 'tests'

function generateRoute(route: string) {
    return () => import(`../views/${viewFolder}/${route}.vue`)
}

function setLayout(layout: string) {
    return defineAsyncComponent(() => import(`../layouts/${layout}.vue`))
}


const routes = [
    {
        path: "/VuexStore",
        name: "VuexStore",
        component: generateRoute('VuexStore'),
        meta: {
            title: 'VuexStore',
            layout: setLayout('AdminLayout'),
            role: 'Admin'
        }
    }
]



export default routes
