import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
// import EventListView from "@/views/Events/EventListView.vue";
// import EventCreate from "@/views/Events/EventCreate.vue";
// import EventDetail from "@/views/Events/EventDetail.vue";

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        { path: '/', name: 'home', component: HomeView },
        // { path: '/events', name: 'events', component: EventListView },
        // { path: '/events/create', name: 'events-create', component: EventCreate },
        // { path: '/events/:id', name: 'events-detail', component: EventDetail },
    ]
})

export default router
