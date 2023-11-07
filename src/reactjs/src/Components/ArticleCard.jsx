import {useEffect, useState} from "react";
import {HttpService} from "../Services/HttpService.js";

export function ArticleCard({article}) {
    return (
        <div className="col">
            <div className="card">
                <img src={"https://localhost:7063/img/" + article.image} className="card-img-top" alt="..."/>
                <div className="card-body">
                    <h5 className="card-title">{article.name}</h5>
                    <p className="card-text gap-1">
                        <span
                            className={`badge text-bg-primary me-2 ${article.onDiscount ? "text-decoration-line-through" : ""}`}>
                            {article.basePrice} €
                        </span>
                        {article.onDiscount
                            ?
                            <span className="badge text-bg-danger">
                                    {article.discountPrice.toFixed(2)} €
                                </span>
                            :
                            null
                        }
                    </p>
                    <p className="card-text">{article.description}</p>
                </div>
            </div>
        </div>
    )
}