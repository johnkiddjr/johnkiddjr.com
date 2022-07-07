import get from 'axios';

const getHomePage = async () => {
  try {
    const { data: response } = await get(`${process.env.VUE_APP_API_ENDPOINT}/api/home`);
    return response;
  } catch (error) {
    return error;
  }
};

export default getHomePage;
