import get from 'axios';

const getContactPage = async () => {
  try {
    const { data: response } = await get(`${process.env.VUE_APP_API_ENDPOINT}/api/contact`);
    return response;
  } catch (error) {
    return error;
  }
};

export default getContactPage;
