<script setup>
import { useHead } from "@unhead/vue/legacy";

useHead({
  title: 'CivicPlus - Andrew Bielecki',
})

</script>

<template>
<main>
  <div class="columns is-multiline is-centered">
    <div class="column is-two-thirds is-full-mobile">
      <div class="card">
        <div class="card-content">
          <h1 class="title is-2">Andrew Bielecki CivicPlus</h1>
          <p>
            Hello, thanks for taking a look at my solution to your code challge. You can find the Github repository
            here: <a href="https://github.com/missitnoonan/civicplus-dotnet">CivicPlus code challenge</a>. This account is pretty barren as I
            only use it for code challenges such as this and then make the repos private. You can find my main GitHub
            account at <a href="https://github.com/ambielecki">Andrew Bielecki's GitHub</a>. This is primarily being
            used for work at the moment.
          </p>
          <br>
<!--          <p>-->
<!--            You can find the main Events page here: <router-link :to="{ name: 'events'}">Events Page</router-link> or-->
<!--            use the navigation link above. This will load the first 20 events and hase simple navigation at the bottom.-->
<!--            Ordering and filtering are not included as they were not part of the requirements.-->
<!--          </p>-->
<!--          <br>-->
<!--          <p>-->
<!--            The Events create page is located here: <router-link :to="{ name: 'events-create' }">Create Event</router-link>.-->
<!--            This page can also be reached through a button / link on the top of the list page. There is minimal client-->
<!--            side validation, but enough to show the concept. You are returned to list page after creation.-->
<!--          </p>-->
          <br>
          <p>
            There is obviously plenty that is not included, additional tests, a notification system, more validation,
            etc, etc. There are a number of faked events created through a seeder like script in the backend, enough
            to demonstrate pagination.
          </p>
          <br>
          <p>
            Please reach out with any questions at <a href="mailto:ambielecki@gmail.com">ambielecki@gmail.com</a>
            or connect on <a href="https://www.linkedin.com/in/andrew-bielecki-5835b5123/">LinkedIn</a>.
          </p>
        </div>
      </div>
    </div>
  </div>
</main>
</template>
