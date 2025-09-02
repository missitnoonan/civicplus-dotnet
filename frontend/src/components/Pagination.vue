<script setup>
import { computed } from "vue";

const props = defineProps(['routeName', 'currentPage', 'pages']);
const emit = defineEmits(['navigate']);

const showPrevious = computed(() => {
  return props.currentPage !== 1;
});
const previousPage = computed(() => {
  return props.currentPage - 1;
});

const showNext = computed(() => {
  return props.currentPage !== props.pages;
});
const nextPage = computed(() => {
  return props.currentPage + 1;
})

//still want to build links, but a query change does not reload the page, this signals to fetch data
function navigate(toPage) {
  emit('navigate', toPage)
}

</script>

<template>
<nav role="navigation" aria-label="pagination">
  <div class="card">
    <div class="card-content">
      <p class="title is-5">Page {{currentPage}} of {{pages}}</p>
      <div class="field is-grouped">
        <p v-if="showPrevious" class="control">
          <router-link
              class="button is-link"
              :to="{ name: routeName, query: { page: previousPage }}"
              @click="navigate(previousPage)"
              id="previous"
          >
            Previous Page
          </router-link>
        </p>
        <p v-if="showNext" class="control">
          <router-link
              class="button is-link"
              :to="{ name: routeName, query: { page: nextPage }}"
              @click="navigate(nextPage)"
              id="next"
          >
            Next Page
          </router-link>
        </p>
      </div>
    </div>
  </div>
</nav>
</template>