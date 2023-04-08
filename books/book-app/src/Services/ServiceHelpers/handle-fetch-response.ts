export function handleFetchResponse(response: Response) {
    return response.text().then(text => {
        if (!response.ok) {
            return Promise.reject(text);
        }
        let data = text && JSON.parse(text);
        return data;
    });
}