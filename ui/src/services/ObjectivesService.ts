import get from 'axios';

export default function getObjectivesPage() {
  get(`${process.env.VUE_APP_API_ENDPOINT}/api/objectives`)
    .then((response) => response)
    .catch((error) => console.log(error));
}
