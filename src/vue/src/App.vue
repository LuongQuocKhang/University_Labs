<template>
	<div>
		<Navbar />
	</div>

	<div class="container">
		<RouterView />
	</div>
</template>


<script lang="js">
import { RouterView } from 'vue-router'

import axios from 'axios';
import Navbar from './components/Navbar.vue';

export default {
    name: "App",
    setup() {
        return {};
    },
    mounted() {
        axios.get(import.meta.env.VITE_API_URL + "/app-users/Guardian", {
            headers: {
                "Content-Type": "application/json"
            },
            withCredentials: true
        }).then(response => {
            if(response != null) {

				let data = response.data;

				let securityGroups = data.securityGroups;
				let student = securityGroups.filter(x => x.name == "Student");
				let teacher = securityGroups.filter(x => x.name == "Teacher");

				let userData = {
					email: data.email,
					firstname: data.firstname,
					lastname: data.lastname,
					isStudent: student.length > 0,
					isTeacher: teacher.length > 0,
					picture: 'https://arp.mantu.com/abook/Telecom/GetEmployeeThumbnail/19740'
				}

				localStorage.setItem("User", JSON.stringify(userData));
			}
        });
    },
    components: { Navbar }
};
</script>
