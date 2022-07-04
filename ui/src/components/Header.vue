<template>
  <nav>
    <router-link to="/">Home</router-link> |
    <router-link to="/portfolio">Portfolio</router-link> |
    <router-link to="/objectives">Objectives</router-link> |
    <router-link to="/about">About</router-link> |
    <router-link to="/contact">Contact</router-link>
  </nav>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'HeaderComponent',
});
</script>
