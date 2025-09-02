<script setup>
import { RouterLink, RouterView } from 'vue-router'
import Nav from "@/components/Nav.vue";
</script>

<template>
<div class="main_container">
  <Nav />
  <div class="container app_container">
    <RouterView />
  </div>
</div>

</template>

<style scoped>
.main_container {
  min-height: calc(100vh - 3.5rem);
}
</style>