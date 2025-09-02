<script setup>
const props = defineProps(['input_name', 'input_label', 'input_placeholder', 'error', 'modelValue']);
const emit = defineEmits(['update:modelValue', 'enter']);

function updateInput() {
  emit('update:modelValue', event.target.value);
}
</script>

<template>
<div class="field">
  <label class="label" :for="input_name">{{ input_label }}</label>
  <div class="control">
    <textarea
        class="textarea is-medium"
        :id="input_name"
        :name="input_name"
        :value="modelValue"
        @input="updateInput"
    ></textarea>
  </div>
</div>

<div v-if="error" class="field is-grouped is-horizontal">
  <div class="field-body">
    <div class="control">
      <p class="help is-danger">
        {{ error }}
      </p>
    </div>
  </div>
</div>
</template>