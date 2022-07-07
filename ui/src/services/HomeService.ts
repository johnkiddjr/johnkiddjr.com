import get from 'axios';

export default function getHomePage() {
  get(`${process.env.VUE_APP_API_ENDPOINT}/api/home`)
    .then((response) => response)
    .catch((error) => console.log(error));
}
