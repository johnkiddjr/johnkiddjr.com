import get from 'axios';

export const getArticleIndexPage = async () => {
  try {
    const { data: response } = await get(`${process.env.VUE_APP_API_ENDPOINT}/api/article`);
    return response;
  } catch (error) {
    return error;
  }
};

export const getArticlePage = async (articleStub: string) => {
  try {
    const { data: response } = await get(`${process.env.VUE_APP_API_ENDPOINT}/api/article/${articleStub}`);
    return response;
  } catch (error) {
    return error;
  }
};
