import get from 'axios';

const getObjectivesPage = async () => {
  try {
    const { data: response } = await get(`${process.env.VUE_APP_API_ENDPOINT}/api/objectives`);
    return response;
  } catch (error) {
    return error;
  }
};

export default getObjectivesPage;
