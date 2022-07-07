const getResume = (resumeId: string) => `${process.env.VUE_APP_API_ENDPOINT}/api/contact/${resumeId}`;

export default getResume;
