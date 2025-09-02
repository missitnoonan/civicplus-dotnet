<script setup>
const props = defineProps(['input_name', 'input_label', 'input_placeholder', 'type', 'modelValue', 'error']);
const emit = defineEmits(['update:modelValue', 'enter']);

function updateInput() {
  emit('update:modelValue', event.target.value);
}
</script>

<template>
<div class="field">
  <label class="label" :for="input_name">{{ input_label }}</label>
  <div class="control">
    <input
        class="input"
        type="text"
        :name="input_name"
        :value="modelValue"
        :placeholder="input_placeholder"
        :type="type ?? 'text'"
        @input="updateInput"
        @keyup.enter="$emit('enter')"
    >
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