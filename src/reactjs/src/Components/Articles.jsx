import {useEffect, useRef, useState} from "react";
import {HttpService} from "../Services/HttpService.js";
import {ArticleCard} from "./ArticleCard.jsx";
import {ArticleFilters} from "./ArticleFilters.jsx";
import {Spinner} from "./Spinner.jsx";

export function Articles() {
    const [articles, setArticles] = useState([]);
    const [categories, setCategories] = useState([]);
    const [selectedCategory, setSelectedCategory] = useState(null)
    const [checkedDiscount, setCheckedDiscount] = useState(null)
    const loadingRef = useRef(true)

    // OnInitialized
    useEffect(() => {
        HttpService.GetCategories()
            .then(categories => setCategories(categories))
            .finally(() => loadingRef.current = false)
    }, []);

    // Update Articles
    useEffect(() => {
        loadingRef.current = true;
        HttpService.GetArticles(selectedCategory, checkedDiscount)
            .then(articles => setArticles(articles))
            .finally(() => loadingRef.current = false)
    }, [selectedCategory, checkedDiscount])
    
    return (
        <div className="row mb-5">
            <div className="col-sm-12 col-lg-3 mb-5">
                <ArticleFilters categories={categories} onSelected={setSelectedCategory}
                                onChecked={setCheckedDiscount}/>
            </div>
                
            <div className="col-sm-12 col-lg-9">
                {loadingRef.current && <Spinner/>}

                {articles != null
                    ?
                    <div className="row row-cols-1 row-cols-md-3 g-4">
                        {
                            articles.map(article => (
                                <ArticleCard article={article} key={article.id}/>
                            ))
                        }
                    </div>
                    :
                    <div>
                        <p className="text-center fs-2">Aucun Résultat</p>
                    </div>
                }
            </div>
        </div>
    )
}