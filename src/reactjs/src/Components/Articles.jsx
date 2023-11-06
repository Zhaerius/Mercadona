import {useEffect, useState} from "react";
import {HttpService} from "../Services/HttpService.js";

export function Articles() {
    const [articles, setArticles] = useState([]);
    
    useEffect(() => {
        HttpService.GetArticles()
            .then(articles => setArticles(articles))
    }, []);
    
    const articlesToDisplay = articles.map(user => (
        <tr key={user.id}>
            <td>{user.id}</td>
            <td>{user.name}</td>
            <td>{user.numberArticles}</td>
        </tr>
    ));
    
    return (
        <table className="table">
            <thead>
                <tr>
                    <th scope="col">id</th>
                    <th scope="col">name</th>
                    <th scope="col">nbart</th>
                </tr>
            </thead>
            <tbody>
                { articlesToDisplay }
            </tbody>
        </table>
    )
}