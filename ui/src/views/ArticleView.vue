<template>
    <div class="article-detail">
        <h1>{{ viewData.title }}</h1>
        <h5>
            Written by: {{ viewData.author }} on
            {{ (new Date(viewData.publishDate)).toLocaleString() }}
        </h5>
        <div v-html="viewData.htmlText"></div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { getArticlePage } from '../services';

export default defineComponent({
  name: 'ArticleView',
  data() {
    return {
      viewData: {
        author: String,
        htmlText: String,
        previewText: String,
        publishDate: String,
        slug: String,
        title: String,
        visible: Boolean,
      },
    };
  },
  created() {
    this.retrieveArticleData();
  },
  methods: {
    async retrieveArticleData() {
      this.viewData = await getArticlePage(this.$route.params.slug);
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
