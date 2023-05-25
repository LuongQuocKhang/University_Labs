<template>
    <div>
        <div class="row">
            <div class="col-md-12">
                <div class="h-100 d-flex align-items-center justify-content-center">
                    <div class="d-flex search-bar">
                        <input class="form-control me-1" 
                        v-model="searchData"
                        type="search" 
                        placeholder="Search" 
                        aria-label="Search">
                        <button class="btn btn-outline-primary"
                        @click="searchCourse">Search</button>
                    </div>
                </div>
            </div>
        </div>
        <div class="row mt-5">
            <div class="col-md-3" v-for="course in courses" :key="course.id">

                <div class="card">
                    <img class="card-img-top" v-bind:src="course.imageURL" alt="Card image cap">
                    <div class="card-body d-flex flex-column">
                        <h5 class="card-title">{{ course.courseName }}</h5>
                        <p class="card-text replace-string">
                            {{ truncate(course.description, 100) }}
                        </p>
                        <a href="javascript:;" class="btn btn-default mt-auto"
                        style="margin-bottom: 10px;">${{ course.courseCredit }}</a>
                        <a href="#" class="btn btn-primary mt-auto">Enroll</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import axios from 'axios';

export default {

    name: "course-view",
    methods: {
        truncate(str, n) {
            return (str.length > n) ? str.slice(0, n - 1) + '...' : str;
        },
        searchCourse() {
            if(this.searchData == null) {
                this.searchData = '';
            }
            axios.get(import.meta.env.VITE_API_GET_COURSE_BY_NAME + this.searchData, {
            headers: {
                "Content-Type": "application/json"
            },
            withCredentials: true
            }).then(response => {
                this.courses = response.data
            });
        }
    },
    setup() {
        return {

        }
    },
    data() {
        return {
            courses: null,
            searchData: ""
        }
    },
    mounted() {
        axios.get(import.meta.env.VITE_API_URL + "/course", {
            headers: {
                "Content-Type": "application/json"
            },
            withCredentials: true
        }).then(response => {
            this.courses = response.data
        });
    }
};
</script>