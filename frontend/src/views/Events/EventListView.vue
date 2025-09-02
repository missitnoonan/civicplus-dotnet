<script setup>

import { computed, onMounted, ref, watch } from "vue";
import EventApiProvider from "@/providers/EventApiProvider.js";
import EventListCard from "@/components/Events/EventListCard.vue";
import { useHead } from '@unhead/vue'
import { useRoute, useRouter } from "vue-router";
import Pagination from "@/components/Pagination.vue";

useHead({
  title: 'CivicPlus - Event List'
})

const route = useRoute();

const events = ref([]);
const hasLoaded = ref(false);

const total = ref(0);
const page = ref(0);

const pages = computed(() => {
  return Math.ceil(total.value / 20); // using the default take
});

const showPagination = computed(() => {
  return total.value > 20;
})

onMounted(() => {
  page.value = parseInt(route.query?.page) || 1;
  getEvents();
});

function handleNavigation(navigateTo) {
  page.value = navigateTo;
  events.value = [];
  getEvents();
}

function getEvents() {
  EventApiProvider.getEventList(page.value)
      .then(json => {
        if (json) {
          events.value = json.items;
          total.value = json.total;
        }
        hasLoaded.value = true;
      })
}

</script>

<template>
<main>
  <div class="container">
    <div class="columns is-multiline">
      <div class="column is-full">
        <div class="card">
          <div class="card-content">
            <div class="content">
              <div class="columns is-mobile is-multiline">
                <div class="column is-full-mobile is-three-quarters">
                  <h1>Events</h1>
                </div>
                <div class="column">
                  <router-link :to="{ name: 'events-create' }" class="button is-link">
                    Create New Event
                  </router-link>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div class="column is-one-quarter" v-for="event in events">
        <EventListCard :event="event" :show-details="false"/>
      </div>
      <div v-if="showPagination" class="column is-full">
        <Pagination
            :currentPage="page"
            :pages="pages"
            route-name="events"
            @navigate="handleNavigation"
        />
      </div>
    </div>
  </div>
</main>
</template>

<style scoped>
h1 {
  margin-bottom: 0;
}
</style>