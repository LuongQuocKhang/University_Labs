import { createRouter, createWebHistory } from 'vue-router'

import HomeView from '../views/HomeView.vue'

import CourseView from '../views/course/CourseView.vue'
import EnrolledCourseView from '../views/course/EnrolledCourseView.vue'
import ClosedCourseView from '../views/course/ClosedCourseView.vue'

import SearchView from '../views/SearchView.vue'
import UserManagementView from '../views/UserManagementView.vue'

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: '/',
            name: 'home',
            component: HomeView
        },
        {
            path: '/search',
            name: 'search',
            component: SearchView
        },
        {
            path: '/course',
            name: 'course',
            component: CourseView
        },
        {
            path: '/enrolled-course',
            name: 'enrolled course',
            component: EnrolledCourseView
        },
        {
            path: '/closed-course',
            name: 'closed-course',
            component: ClosedCourseView
        },
        {
            path: '/user-management',
            name: 'user-management',
            component: UserManagementView
        }
    ]
})

export default router
