<template>
    <div class="article-index">
        <h1>Articles</h1>
        <ul v-if="viewData.articles">
        <li v-for="article in viewData.articles" :key="article.slug">
          <router-link :to="'/articles/' + article.slug"><h3>{{ article.title }}</h3></router-link>
          <p>{{ article.previewText }}</p>
        </li>
      </ul>
      <span v-else>No articles to show</span>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { getArticleIndexPage } from '../services';

export default defineComponent({
  name: 'ArticleIndexView',
  data() {
    return {
      viewData: {
        articles: [],
      },
    };
  },
  created() {
    this.retrieveArticleData();
  },
  methods: {
    async retrieveArticleData() {
      this.viewData = await getArticleIndexPage();
      console.log(this.viewData);
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
