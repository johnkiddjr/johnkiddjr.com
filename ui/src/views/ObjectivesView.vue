<template>
  <div class="objectives">
    <h1>Objectives</h1>
    <div class="bodytext">
      <div v-for="objective in viewData.objectives" :key="objective.name">
        <h2>{{ objective.name }}</h2>
        <p>{{ objective.description }}</p>
        <ul v-if="objective.details">
          <li v-for="detail in objective.details" :key="detail.name">
            <a :href="detail.linkUrl">{{ detail.name }}</a>
          </li>
        </ul>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { getObjectivesPage } from '../services';

export default defineComponent({
  name: 'ObjectivesView',
  data() {
    return {
      viewData: {},
    };
  },
  created() {
    this.retrieveObjectivesData();
  },
  methods: {
    async retrieveObjectivesData() {
      this.viewData = await getObjectivesPage();
    },
  },
});
</script>
