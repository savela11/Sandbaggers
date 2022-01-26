import DefaultLayout from "@/layouts/DefaultLayout.vue";

function generateRoute(route: string) {
    return () => import(`../views/auth/${route}.vue`)
}

const routes = [
    {
        path: '/Login',
        name: 'Login',
        component: generateRoute('Login'),
        meta: {
            title: 'Login',
            layout: DefaultLayout
        }
    },

    {
        path: '/Register',
        name: 'Register',
        component: generateRoute('Register'),
        meta: {
            title: 'Register',
            layout: DefaultLayout
        }
    },

]



export default routes;