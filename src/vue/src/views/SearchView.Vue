<template>
    <div class="h-100 d-flex align-items-center justify-content-center">
        <form class="d-flex search-bar">
            <input class="form-control me-1" type="search" placeholder="Search" aria-label="Search">
            <button class="btn btn-outline-primary" type="submit">Search</button>
        </form>
    </div>
</template>

<script lang="ts">

export default {
    name: "search-view",
    methods: {
        
    },
    setup() {
        return {

        }
    },
    data() {
        return {
            courses: null
        }
    },
    mounted() {

    }
}
</script>


<style>
.search-bar {
    width: 40rem;
}
</style>