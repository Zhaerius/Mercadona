import config from "../config.json"

export function ArticleCard({article}) {
    return (
        <div className="col">
            <div className="card bg-white">
                <div className="card-img-top card-div d-flex align-items-start justify-content-end"
                     style={{backgroundImage: `url("${config.API_URL}/img/${article.image}")`}} >
                        {article.currentPromotion != null &&
                            <p className="fw-semibold py-1 px-2 rounded-1 bg-price text-white m-2">
                                Promo {article.currentPromotion.discount}%
                            </p>}
                </div>
                <div className="card-body">
                    <h5 className="card-title text-dark">{article.name}</h5>
                    <p className="card-text gap-1">
                        <span
                            className={`fw-semibold py-1 px-2 rounded-1 bg-light text-light-emphasis me-2 ${article.onDiscount ? "text-decoration-line-through" : ""}`}>
                            {article.basePrice} €
                        </span>
                        {article.onDiscount &&
                            <span className="fw-semibold py-1 px-2 rounded-1 bg-primary text-white">
                                {article.discountPrice.toFixed(2)} €
                            </span>}
                    </p>
                    <p className="card-text text-body-secondary">{article.description}</p>
                </div>
            </div>
        </div>
    )
}