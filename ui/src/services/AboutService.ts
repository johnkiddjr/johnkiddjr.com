import get from 'axios';

const getAboutPage = async () => {
  try {
    const { data: response } = await get(`${process.env.VUE_APP_API_ENDPOINT}/api/about`);
    return response;
  } catch (error) {
    return error;
  }
};

export default getAboutPage;
