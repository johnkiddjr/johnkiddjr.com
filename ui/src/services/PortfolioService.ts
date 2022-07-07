import get from 'axios';

const getPortfolioPage = async () => {
  try {
    const { data: response } = await get(`${process.env.VUE_APP_API_ENDPOINT}/api/portfolio`);
    return response;
  } catch (error) {
    return error;
  }
};

export default getPortfolioPage;
