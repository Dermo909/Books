import { getBody } from "../Components/Helpers/body-helper";
import { getHeader } from "../Components/Helpers/header-helper";
import { API_URL } from "../Consts/configConst";
import { BookVM } from "../ViewModels/BookVM";
import { handleFetchResponse } from "./ServiceHelpers/handle-fetch-response";

const API_NAME = "book";

export const bookService = {
    getAll,
    disable,
    put
}

function getAll() {
    return fetch(`${API_URL}/${API_NAME}/getAll`).then(handleFetchResponse);
}

function disable(id: number) {
    const requestOptions = { method: 'DELETE'};
    return fetch(`${API_URL}/${API_NAME}/${id}`, requestOptions).then(handleFetchResponse);
}

function put(model?: BookVM) {
    console.log('put: ', model)
    const requestOptions = { method: 'PUT', headers: getHeader(), body: getBody(model) };
    return fetch(`${API_URL}/${API_NAME}`, requestOptions).then(handleFetchResponse);
}