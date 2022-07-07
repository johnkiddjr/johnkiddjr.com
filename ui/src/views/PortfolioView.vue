<template>
  <div class="portfolio">
    <h1>Portfolio</h1>
    <div class="section bodytext">
      <h2>Projects</h2>
      <ul v-if="projectData">
        <li v-for="project in projectData.projects" :key="project.name">
          <a :href="project.directUrl"><h3>{{ project.name}}</h3></a>
          <table>
            <tr>
              <td class="align-top">
                {{ project.description }}
              </td>
              <td v-if="project.pictureUrl">
                <img :src="project.pictureUrl" width="300" :alt="project.name" />
              </td>
            </tr>
          </table>
        </li>
      </ul>
      <span v-else>No projects to show</span>
    </div>
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
import { getPortfolioPage, getProjectsPage } from '../services';

export default defineComponent({
  name: 'PortfolioView',
  data() {
    return {
      viewData: {
        linkGroups: [{
          groupName: '',
          links: [{
            link: '',
            text: '',
          }],
        }],
      },
      projectData: {
        projects: [{
          description: '',
          directUrl: '',
          name: '',
          pictureUrl: '',
        }],
      },
    };
  },
  created() {
    this.retrievePortfolioData();
  },
  methods: {
    async retrievePortfolioData() {
      this.viewData = await getPortfolioPage();
      this.projectData = await getProjectsPage();
    },
  },
});
</script>

<style lang="scss">
td.align-top {
  vertical-align: top;
}
</style>
