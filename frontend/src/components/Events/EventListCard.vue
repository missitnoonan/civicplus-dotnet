<script setup>
import { computed } from "vue";
import { useFormatDate } from "@/composables/useFormatDate.js";

const props = defineProps(['event', 'showDetails']);

const startDate = computed(() => {
  return useFormatDate(props.event?.startDate);
});

const endDate = computed(() => {
  return useFormatDate(props.event?.endDate);
});

</script>

<template>
<article>
  <div class="card">
    <div class="card-content">
      <h2 class="title is-4" data-testid="title">{{ event.title }}</h2>
      <p data-testid="startDate">
        <b>Start: </b>{{ startDate }}
      </p>
      <p data-testid="endDate">
        <b>End: </b>{{ endDate }}
      </p>
      <div v-if="showDetails">
        <br>
        <p data-testid="description">{{ event.description }}</p>
      </div>
      <div v-else>
        <router-link
            :to="{ name: 'events-detail', params: { id: event.id }}"
            :aria-describedby="event.id"
            data-testid="link"
        >
          View details
        </router-link>
        <p class="is-sr-only" :id="event.id">For {{ event.title }}</p>
      </div>
    </div>
  </div>
</article>
</template>