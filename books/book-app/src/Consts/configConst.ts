const LOCAL_API_URL = "https://localhost:7266";
const PROD_API_URL = "https://books-api-dg.azurewebsites.net";

const LOCAL_APP_URL = "https://localhost:3000";
const PROD_APP_URL = "https://books-app-dg.azurewebsites.net";

const API_URL = process.env.REACT_APP_STAGE === 'prod' ? PROD_API_URL : LOCAL_API_URL;
const APP_URL = process.env.REACT_APP_STAGE === 'prod' ? PROD_APP_URL : LOCAL_APP_URL;

export { API_URL, APP_URL }