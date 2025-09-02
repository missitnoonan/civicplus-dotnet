<script setup>
import EventFormCard from "@/components/Events/EventFormCard.vue";
import { useHead } from '@unhead/vue'

useHead({
  title: 'CivicPlus - Event Create'
})
</script>

<template>
<main>
  <div class="container">
    <div class="columns">
      <div class="column is-full">
        <div class="card">
          <div class="card-content">
            <div class="content">
              <h1>Create Event</h1>
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="columns">
      <div class="column">
        <EventFormCard />
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