export function ArticleFilters({categories, onSelected, onChecked}) {
    
    const handleClick = () => {
        onSelected(document.querySelector(".form-select").value)
        onChecked(document.querySelector("#flexSwitchCheckDefault").checked)
    }

    return (
        <>
            <select className="form-select" aria-label="Default select example">
                <option value="">All</option>
                {
                    categories.map(category => (
                        <option value={category.id} key={category.id}>
                            {category.name}
                        </option>
                    ))
                }
            </select>

            <div className="form-check form-switch">
                <input className="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckDefault" />
                <label className="form-check-label" htmlFor="flexSwitchCheckDefault">En promotion</label>
            </div>
            
            <button className="btn btn-primary" onClick={handleClick}>Valider</button>
        </>
    )
}