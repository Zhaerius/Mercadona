export class HttpService {
    static GetArticles() {
        const url = "https://localhost:7063/article?Publish=true";
         return fetch(url, {
            method: "GET"
        })
            .then(response => response.json())
    }
}