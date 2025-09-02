<script setup>
// this may be set up differently if we want to allow editing and need a Event model
import { computed, ref } from "vue";
import EventApiProvider from "@/providers/EventApiProvider.js";
import TextInput from "@/components/Inputs/TextInput.vue";
import TextAreaInput from "@/components/Inputs/TextAreaInput.vue";
import VueDatePicker from '@vuepic/vue-datepicker';
import '@vuepic/vue-datepicker/dist/main.css'
import { useRouter } from "vue-router";

const title = ref('');
const description = ref('');
const startDate = ref('');
const endDate = ref('');
const router = useRouter();

const formattedStartDate = computed(() => {
  return formatDate(startDate.value);
});

const formattedEndDate = computed(() => {
  return formatDate(endDate.value);
});

const loading = ref(false);
const errors = ref({});
const hasErrors = ref(false);

function submitEvent() {
  loading.value = true;
  validate();

  if (!hasErrors.value) {
    EventApiProvider.postEvent({
      title: title.value,
      description: description.value,
      startDate: formattedStartDate.value,
      endDate: formattedEndDate.value,
    }).then(saved => {
      if (saved) {
        // would usually push a notification that the save was successful
        router.push({ name: 'events' });
      } else {
        console.log('there was a problem')
      }
    })
  }

  loading.value = false;
}

function validate() {
  // this is just going to be some very basic validation and would normally be in another helper
  hasErrors.value = false;
  errors.value = {};

  if (title.value.length < 3) {
    hasErrors.value = true;
    errors.value.title = 'Title Must Be Longer than 3 characters'
  }

  if (description.value.length < 3) {
    hasErrors.value = true;
    errors.value.description = 'Description Must Be Longer than 3 characters'
  }

  if (!startDate.value) {
    hasErrors.value = true;
    errors.value.startDate = 'Start Date Is Required'
  }

  if (!endDate.value) {
    hasErrors.value = true;
    errors.value.endDate = 'End Date Is Required'
  }
}

function formatDate(value) {
  const date = new Date(value);

  return date.toISOString();
}

</script>

<template>
<form @submit.prevent>
  <div class="card">
    <div class="card-content">
      <TextInput
          input_label="Title"
          input_placeholder="Event Title"
          input_name="title"
          v-model="title"
          :error="errors.title"
          @enter="submitEvent"
      />

      <TextAreaInput
          input_label="Description"
          input_placeholder="Event Description"
          input_name="description"
          :error="errors.description"
          v-model="description"
      />

      <div class="field">
        <label class="label" for="start_date">Start Date</label>
        <div class="control">
          <VueDatePicker :name="'start_date'" :is24="false" v-model="startDate"></VueDatePicker>
        </div>
      </div>

      <div v-if="errors.startDate" class="field is-grouped is-horizontal">
        <div class="field-body">
          <div class="control">
            <p class="help is-danger">
              {{ errors.startDate }}
            </p>
          </div>
        </div>
      </div>

      <div class="field">
        <label class="label" for="end_date">End Date</label>
        <div class="control">
          <VueDatePicker :name="'end_date'" :is24="false" v-model="endDate"></VueDatePicker>
        </div>
      </div>

      <div v-if="errors.endDate" class="field is-grouped is-horizontal">
        <div class="field-body">
          <div class="control">
            <p class="help is-danger">
              {{ errors.endDate }}
            </p>
          </div>
        </div>
      </div>

      <div class="field">
        <p class="control">
          <button
              class="button is-link"
              :class="{ 'is-loading': loading }"
              @click="submitEvent"
          >
            Create Event
          </button>
        </p>
      </div>

    </div>
  </div>
</form>
</template>