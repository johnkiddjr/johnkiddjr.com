import get from 'axios';

const getResume = async (resumeId: string) => {
  try {
    const { data: response } = await get(`${process.env.VUE_APP_API_ENDPOINT}/api/contact/${resumeId}`);
    return response;
  } catch (error) {
    return error;
  }
};

export default getResume;
