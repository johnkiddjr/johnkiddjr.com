import get from 'axios';

const getProjectsPage = async () => {
  try {
    const { data: response } = await get(`${process.env.VUE_APP_API_ENDPOINT}/api/projects`);
    return response;
  } catch (error) {
    return error;
  }
};

export default getProjectsPage;
