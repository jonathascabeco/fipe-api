<template>
  <div>
    <h1>Cars</h1>
    <CarGrid />
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import CarGrid from './components/car-grid/CarGrid.vue';

export default defineComponent({
  components: {
    CarGrid,
  },
});
</script>