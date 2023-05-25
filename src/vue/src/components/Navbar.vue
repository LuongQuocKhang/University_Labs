<template>
    <div class="nav-container mb-3">
        <nav class="navbar navbar-expand-md navbar-light bg-light">
            <div class="container">
                <div class="navbar-brand logo"></div>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav"
                    aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <div class="collapse navbar-collapse" id="navbarNav">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item">
                            <router-link to="/" class="nav-link">Home</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link to="/search" class="nav-link">Search User</router-link>
                        </li>
                        <li class="nav-item" v-if="this.user.isTeacher">
                            <router-link to="/user-management" class="nav-link">User Management</router-link>
                        </li>
                        <li class="nav-item" v-if="this.user.isTeacher">
                            <router-link to="/course-management" class="nav-link">Course Management</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link to="/course" class="nav-link">Courses</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link to="/enrolled-course" class="nav-link">Enrolled Courses</router-link>
                        </li>
                        <li class="nav-item">
                            <router-link to="/closed-course" class="nav-link">Closed Courses</router-link>
                        </li>
                    </ul>
                    <ul class="navbar-nav d-none d-md-block">
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" id="profileDropDown" data-toggle="dropdown">
                                <img :src="user.picture" alt="User's profile picture"
                                    class="nav-user-profile rounded-circle" width="50" />
                                    {{ user.email }}
                            </a>
                            <div class="dropdown-menu dropdown-menu-right">
                                <!-- <div class="dropdown-header">{{ user.email }}</div> -->
                                <router-link to="/profile" class="dropdown-item dropdown-profile">
                                    <font-awesome-icon class="mr-3" icon="user" />Profile
                                </router-link>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    </div>
</template>

<script lang="js">

export default {
    name: "NavBar",
    data() {
        return {
            user: {
                email: '',
                firstname: '',
                lastname: '',
                isStudent: false,
                isTeacher: false,
                picture: ''
            }
        }
    },
    setup() {
        return {

        }
    },
    mounted() {
        let loggedUser = localStorage.getItem("User");
        this.user = JSON.parse(loggedUser);
    }
};
</script>

<style>
#mobileAuthNavBar {
    min-height: 125px;
    justify-content: space-between;
}
</style>
