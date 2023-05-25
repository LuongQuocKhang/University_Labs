
<template>
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h4> User Management </h4>
            </div>
        </div>
        <div class="row search-bar-div">
            <div class="col-md-12">
                <div class="h-100 d-flex align-items-center justify-content-center">
                    <div class="d-flex search-bar">
                        <input class="form-control me-1" type="search" placeholder="Search" aria-label="Search">
                        <button class="btn btn-outline-primary"
                            @click="searchUser()">Search</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">
                    <table class="table table-hover">
                        <thead>
                            <tr>
                                <th scope="col">Id</th>
                                <th scope="col">Email</th>
                                <th scope="col">First</th>
                                <th scope="col">Last</th>
                                <th scope="col"></th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="user in users" :key="user.id">
                                <th scope="row">{{ user.id }}</th>
                                <td>{{ user.email }}</td>
                                <td>{{ user.firstName }}</td>
                                <td>{{ user.lastName }}</td>
                                <td>
                                    <button type="button" class="btn btn-default btn-default-border"><i
                                            class="bi bi-pencil-square"></i></button>
                                    <button type="button" class="btn btn-danger"><i class="bi bi-trash"></i></button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>

            </div>
        </div>
    </div>
</template>
<style>
.btn-default-border {
    border: 1px solid black;
}

.table td,
.table th {
    vertical-align: middle;
}

.search-bar-div {
    margin-top: 10px;
    margin-bottom: 10px;
}

</style>
<script lang="js">

export default {
    name: "user-management-view",
    methods: {
        searchUser() {
            console.log("searched");
        }
    },
    setup() {
        return {

        }
    },
    data() {
        return {
            users: null
        }
    },
    mounted() {
        this.users = [{
            id: 1,
            email: "khangstudent@gmail.com",
            firstName: "khang",
            lastName: "student"
        },
        {
            id: 2,
            email: "khangtecher@gmail.com",
            firstName: "khang",
            lastName: "teacher"
        }
        ]
    }
}
</script>