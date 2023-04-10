import { API_URL } from "../Consts/configConst";
import { handleFetchResponse } from "./ServiceHelpers/handle-fetch-response";

const API_NAME = "readingList";

export const readingListService = {
    getAll
}

function getAll() {
    return fetch(`${API_URL}/${API_NAME}/getAll`).then(handleFetchResponse);
}