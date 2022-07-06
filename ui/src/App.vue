<template>
  <div>
    <Header />
    <router-view/>
    <Footer />
  </div>
</template>

<script lang="ts">
import Header from './components/Header.vue';
import Footer from './components/Footer.vue';

const linkedInScript = document.createElement('script');
linkedInScript.setAttribute('src', 'https://platform.linkedin.com/badges/js/profile.js');
linkedInScript.setAttribute('type', 'text/javascript');
linkedInScript.async = true;
linkedInScript.defer = true;

document.head.appendChild(linkedInScript);

export default {
  components: {
    Header,
    Footer,
  },
};
</script>

<style lang="scss">

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

nav {
  padding: 0px 30px 30px 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}

.bodytext {
  text-align: left;
  max-width: 800px;
  margin: auto;
}
</style>
