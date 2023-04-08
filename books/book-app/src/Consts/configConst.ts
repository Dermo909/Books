const LOCAL_URL = "https://localhost:7266";
const PROD_URL = "azure_url";

const API_URL = process.env.REACT_APP_STAGE === 'prod' ? PROD_URL : LOCAL_URL;

export { API_URL }