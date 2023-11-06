import {useEffect, useState} from "react";
import {HttpService} from "../Services/HttpService.js";

export function Articles() {
    const [articles, setArticles] = useState([]);
    
    useEffect(() => {
        HttpService.GetArticles()
            .then(articles => setArticles(articles))
    }, []);
    
    const articlesToDisplay = articles.map(user => (
        <div className="col" key={user.id}>
            <div className="card">
                <img src={"https://localhost:7063/img/" + user.image} className="card-img-top" alt="..." />
                <div className="card-body">
                    <h5 className="card-title">{user.name}</h5>
                    <p className="card-text">{user.description}</p>
                    <p className="card-text"><small className="text-body-secondary">{user.basePrice} €</small></p>
                    {user.basePrice !== user.discountPrice 
                        ? <p className="card-text"><small className="text-body-secondary">{user.discountPrice} €</small></p>
                        : null
                    }
                </div>
            </div>
        </div>
    ));
    
    return (
        <div className="row row-cols-1 row-cols-md-3 g-4">
            {articlesToDisplay}
        </div>
    )
}