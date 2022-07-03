<template>
  <div class="contact">
    <h1>Contact Me</h1>
    <span class="bodytext">
      Want to get in touch with me?
      Use the information below to email me, view my resume, or connect with me on LinkedIn.
    </span><br /><br />
    <span class="name">John Kidd Jr</span><br />
    <a href="mailto:johnkiddjr@outlook.com">johnkiddjr@outlook.com</a><br /><br />
    Download a copy of my resume here.<br /><br />
    <div style="width: 250px; margin: auto;">
      <div
        class="badge-base LI-profile-badge"
        data-locale="en_US"
        data-size="medium"
        data-theme="dark"
        data-type="VERTICAL"
        data-vanity="johnkiddjr"
        data-version="v1">
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

const linkedInScript = document.createElement('script');
linkedInScript.setAttribute('src', 'https://platform.linkedin.com/badges/js/profile.js');
linkedInScript.setAttribute('type', 'text/javascript');
linkedInScript.async = true;
linkedInScript.defer = true;

document.head.appendChild(linkedInScript);

export default defineComponent({
  name: 'ContactView',
});
</script>
