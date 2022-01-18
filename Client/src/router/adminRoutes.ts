import {NavigationGuardNext} from 'vue-router'
import AdminLayout from "@/layouts/AdminLayout.vue";


// import AuthLayout from '@/layouts/authLayouts/AuthLayout.vue'
// import AuthLayoutNoNavBar from '@/layouts/authLayouts/AuthLayoutNoNavBar.vue'
// import AuthLayoutNoHeader from '@/layouts/authLayouts/AuthLayoutNoHeader.vue'
// import AuthLayoutNoBars from '@/layouts/authLayouts/AuthLayoutNoBars.vue'
// import AuthLayoutNoHeaderAlt from "@/layouts/authLayouts/AuthLayoutNoHeader-Alt.vue";

// function loadView(view: string) {
//     return (): Promise<typeof import('*.vue')> => import(/* webpackChunkName: "view-[request]" */ `@/views/admin/${view}.vue`)
// }

function generateRoute(route: string) {
    return () => import(`../views/admin/${route}.vue`)
}

export default [
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
