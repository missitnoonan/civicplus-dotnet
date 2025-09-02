<template>
<nav class="navbar is-link" role="navigation" aria-label="main navigation">
  <div class="navbar-start">
    <router-link :to="{ name: 'home' }" class="navbar-item">CivicPlus</router-link>
    <router-link :to="{ name: 'events' }" class="navbar-item">Events</router-link>
  </div>
</nav>
</template>

<script setup lang="ts">
</script>

<style scoped>
.navbar-start {
  font-size: 1.5rem;
}
</style>