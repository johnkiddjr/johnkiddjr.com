<template>
  <div class="footer">
    &copy; 2022 John Kidd Jr. All rights reserved.
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'FooterComponent',
});
</script>

<style lang="scss">
.footer {
  position: fixed;
  left: 0;
  bottom: 5px;
  width: 100%;
  text-align: center;
  background: white;
}
</style>
