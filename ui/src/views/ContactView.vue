<template>
  <div class="contact">
    <h1>Contact Me</h1>
    <span class="bodytext">
      {{ viewData.contactDetails.headerText }}
    </span><br /><br />
    <span class="name">{{ viewData.contactDetails.name }}</span><br />
    <a :href="'mailto:' + viewData.contactDetails.emailAddress">
      {{ viewData.contactDetails.emailAddress }}
    </a>
    <br /><br />
    Download a copy of my resume <a href="#">here</a>.<br /><br />
    <div style="width: 250px; margin: auto;">
      <div
        class="badge-base LI-profile-badge"
        data-locale="en_US"
        data-size="medium"
        data-theme="dark"
        data-type="VERTICAL"
        data-vanity="johnkiddjr"
        data-version="v1">
        <a class="badge-base__link LI-simple-link" href="https://www.linkedin.com/in/johnkiddjr?trk=profile-badge">
          LinkedIn Card not loaded? Click here to see my LinkedIn profile.
        </a>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { getContactPage } from '../services';

const linkedInScript = document.createElement('script');
linkedInScript.setAttribute('src', 'https://platform.linkedin.com/badges/js/profile.js');
linkedInScript.setAttribute('type', 'text/javascript');
linkedInScript.async = true;
linkedInScript.defer = true;

document.head.appendChild(linkedInScript);

export default defineComponent({
  name: 'ContactView',
  data() {
    return {
      viewData: {},
    };
  },
  created() {
    this.retrieveContactData();
  },
  methods: {
    async retrieveContactData() {
      this.viewData = await getContactPage();
      console.log(this.viewData);
    },
  },
});
</script>
