<template>
  <div class="portfolio">
    <h1>Portfolio</h1>
    <div class="section bodytext">
      <h2>Code</h2>
      <ul>
        <li><a href="https://github.com/johnkiddjr">GitHub Repositories</a></li>
        <li><a href="https://source.kiddclan.com/johnkiddjr">GitLab Repositories</a></li>
      </ul>
    </div>
    <div class="section bodytext">
      <h2>Articles</h2>
      <ul>
        <li>
          <a href="https://www.bizstream.com/blog/january-2022/windows-authentication-with-net-5" target="blank">
            Windows Authentication with .Net 5
          </a>
        </li>
      </ul>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'PortfolioView',
});
</script>
