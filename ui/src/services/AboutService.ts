import get from 'axios';

// export default function getAboutPage() : any {
//   get(`${process.env.VUE_APP_API_ENDPOINT}/api/about`)
//     .then((response) => response.data)
//     .catch((error) => console.log(error));

//   return {};
// }

const getAboutPage = async () => {
  try {
    const { data: response } = await get(`${process.env.VUE_APP_API_ENDPOINT}/api/about`);
    return response;
  } catch (error) {
    return error;
  }
};

export default getAboutPage;
