export class HttpService {
    static GetArticles() {
        const url = "https://mercadonawebapi.azurewebsites.net/category";
         return fetch(url, {
            method: "GET"
        })
            .then(response => response.json())
    }
}