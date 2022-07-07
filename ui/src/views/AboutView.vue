<template>
  <div class="about">
    <h1>{{ viewData.name }}</h1>
    <img :src="viewData.pictureUrl" alt="The man himself" width="300" />
    <div class="bodytext" v-for="section in viewData.sections" :key="section.name">
      <h2>{{ section.name }}</h2>
      <table>
        <tr v-for="detail in section.details" :key="detail.description">
          <td class="align-top">{{ detail.description }}</td>
          <td v-if="detail.photoUrl">
            <img :src="detail.photoUrl" width="300" :alt="section.name" />
          </td>
        </tr>
      </table>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { getAboutPage } from '../services';

export default defineComponent({
  name: 'AboutView',
  data() {
    return {
      viewData: {},
    };
  },
  created() {
    this.retrieveAboutData();
  },
  methods: {
    async retrieveAboutData() {
      this.viewData = await getAboutPage();
    },
  },
});
</script>

<style lang="scss">
.about-sections {
  max-width: 700px;
  margin-left: auto;
  margin-right: auto;
}
td.align-top {
  vertical-align: top;
}
</style>
