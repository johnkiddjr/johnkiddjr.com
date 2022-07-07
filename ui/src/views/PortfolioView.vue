<template>
  <div class="portfolio">
    <h1>Portfolio</h1>
    <div class="section bodytext" v-for="group in viewData.linkGroups" :key="group.groupName">
      <h2>{{ group.groupName }}</h2>
      <ul>
        <li v-for="link in group.links" :key="link.link">
          <a :href="link.link" target="blank">{{ link.text }}</a>
        </li>
      </ul>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { getPortfolioPage } from '../services';

export default defineComponent({
  name: 'PortfolioView',
  data() {
    return {
      viewData: {},
    };
  },
  created() {
    this.retrievePortfolioData();
  },
  methods: {
    async retrievePortfolioData() {
      this.viewData = await getPortfolioPage();
    },
  },
});
</script>
