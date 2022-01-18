import {defineAsyncComponent} from "vue";

const viewFolder = 'tests'

function generateRoute(route: string) {
    return () => import(`../views/${viewFolder}/${route}.vue`)
}

function setLayout(layout: string) {
    return defineAsyncComponent(() => import(`../layouts/__${layout}.vue`))
}


const routes = [
    {
        path: "/StoreNoVuex",
        name: "StoreNoVuex",
        component: generateRoute('StoreNoVuex'),
        meta: {
            title: 'StoreNoVuex',
            layout: setLayout('TestLayout'),
            role: 'Admin'
        }
    },

    {
        path: "/VuexStore",
        name: "VuexStore",
        component: generateRoute('VuexStore'),
        meta: {
            title: 'VuexStore',
            role: 'Admin'
            // layout: setLayout('TestLayout')
        }
    }
]

// router.beforeEach((to: RouteLocationNormalized, from: RouteLocationNormalized, next: NavigationGuardNext) => {
//     let title = "Sandbaggers";
//     if (to.meta.title) {
//         title = to.meta.title as string;
//     }
//
//     document.title = title
//     next();
// })

export default routes
