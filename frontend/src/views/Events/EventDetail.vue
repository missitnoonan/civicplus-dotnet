<script setup>
import { onMounted, ref } from "vue";
import EventApiProvider from "@/providers/EventApiProvider.js";
import { useRoute } from "vue-router";
import { useHead } from '@unhead/vue'
import EventListCard from "@/components/Events/EventListCard.vue";

const route = useRoute();
useHead({
  title: 'CivicPlus - Event Details' // this could be more specific of course
})
const isLoading = ref(true);
const event = ref({});

onMounted(() => {
  EventApiProvider.getEvent(route.params.id)
      .then(response => {
        isLoading.value = false;
        if (response) {
          event.value = response;
        }
      })
})

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
                  <h1>Event Details</h1>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div v-if="!isLoading" class="column is-full">
        <EventListCard :event="event" :show-details="true"/>
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