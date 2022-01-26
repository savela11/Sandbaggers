import AdminLayout from "@/layouts/AdminLayout.vue";


function generateRoute(route: string) {
    return () => import(`../views/admin/${route}.vue`)
}

const routes = [
    {
        path: '/admin',
        name: 'Admin Dashboard',
        component: generateRoute('AdminDashboard'),
        meta: {
            role: 'Admin',
            layout: AdminLayout
        },
    },
    // {
    //     path: '/admin/roles',
    //     name: 'Roles',
    //     component: loadView('roleManager/Roles'),
    //     meta: {
    //         // layout: AuthLayoutNoHeaderAlt,
    //     },
    // },
    // {
    //     path: '/admin/createRole',
    //     name: 'CreateRole',
    //     component: loadView('roleManager/CreateRole'),
    //     meta: {
    //         // layout: AuthLayoutNoHeaderAlt,
    //     },
    // },
    // {
    //     path: '/admin/roles/editRole/:id',
    //     name: 'EditRole',
    //     component: loadView('role/EditRole'),
    //     meta: {
    //         // layout: AuthLayoutNoHeaderAlt,
    //     },
    // },
    // {
    //     path: '/admin/eventManager',
    //     name: 'Event Manager',
    //     component: loadView('eventManager/EventManager'),
    //     meta: {
    //         // layout: AuthLayoutNoHeaderAlt,
    //     },
    // },
    // {
    //     path: '/admin/createEvent',
    //     name: 'Create Event',
    //     component: loadView('eventManager/CreateEvent'),
    //     meta: {
    //         // layout: AuthLayoutNoHeaderAlt,
    //     },
    // },
    // {
    //     path: '/admin/editEvent/:id',
    //     name: 'Edit Event',
    //     component: loadView('eventManager/EditEvent'),
    //     meta: {
    //         // layout: AuthLayoutNoHeaderAlt,
    //     },
    // },
    // {
    //     path: '/admin/events/eventTeams/:eventId',
    //     name: 'Event Teams',
    //     component: loadView('events/EventTeams'),
    //     meta: {
    //         // layout: AuthLayoutNoHeaderAlt,
    //     },
    // },
    //
    // {
    //     path: '/admin/DraftManager/',
    //     name: 'Draft Manager',
    //     component: loadView('draftManager/DraftManager'),
    //     meta: {
    //         // layout: AuthLayoutNoHeaderAlt,
    //     },
    // },
]

routes.forEach(function(r) {
    console.log(r)
    Object.assign(r,  {meta: {...r.meta, requiresAuth: true, role: 'Admin'}})

})
export default routes
