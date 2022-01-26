import UserLayout from '../layouts/UserLayout.vue'

function generateRoute(route: string) {
    return () => import(`../views/user/${route}.vue`)
}



const routes = [
    {
        path: "/dashboard",
        name: "Dashboard",
        component: generateRoute('Dashboard'),
        meta: {
            title: 'Dashboard',
            layout: UserLayout,
            role: 'User'
        }
    }
]



export default routes
