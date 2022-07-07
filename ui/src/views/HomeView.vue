<template>
  <div class="home">
    <h1>Welcome!</h1>
    <h2>{{ viewData.headerText }}</h2>
    <p class="bodytext">
      {{ viewData.bodyHtml }}
    </p>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { getHomePage } from '../services';

export default defineComponent({
  name: 'HomeView',
  data() {
    return {
      viewData: {},
    };
  },
  created() {
    this.retrieveHomeData();
  },
  methods: {
    async retrieveHomeData() {
      this.viewData = await getHomePage();
    },
  },
});
</script>
