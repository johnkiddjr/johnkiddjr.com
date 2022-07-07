import get from 'axios';

export default function getPortfolioPage() {
  get(`${process.env.VUE_APP_API_ENDPOINT}/api/portfolio`)
    .then((response) => response)
    .catch((error) => console.log(error));
}
