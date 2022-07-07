import get from 'axios';

export default function getAboutPage() {
  get(`${process.env.VUE_APP_API_ENDPOINT}/api/about`)
    .then((response) => response)
    .catch((error) => console.log(error));
}
