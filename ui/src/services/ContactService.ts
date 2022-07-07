import get from 'axios';

export default function getContactPage() {
  get(`${process.env.VUE_APP_API_ENDPOINT}/api/contact`)
    .then((response) => response)
    .catch((error) => console.log(error));
}
