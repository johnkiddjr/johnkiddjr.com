<template>
  <div class="home">
    <h1>{{ viewData.headerText }}</h1>
    <p>
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

<style lang="scss">
.home {
  max-width: 700px;
  margin-left: auto;
  margin-right: auto;
}
</style>
