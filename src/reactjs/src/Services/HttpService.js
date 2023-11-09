import config from "../config.json"

export class HttpService {
    static BASE_URL= config.API_URL
    static async GetArticles(selected = null, discount = null) {
        let url = HttpService.BASE_URL + "article?Publish=true";
        
        if (!!selected)
            url = url + `&CategoryId=${selected}`

        if (discount === true)
            url = url + `&OnDiscount=${discount}`
        
         return await fetch(url, { method: "GET" })
            .then(response => {
                if (response.status === 200)
                    return response.json()
                else
                    return null
            })
    }

    static async GetCategories() {
        const url = HttpService.BASE_URL + "category";
        return await fetch(url, {
            method: "GET"
        })
            .then(response => response.json())
    }
}