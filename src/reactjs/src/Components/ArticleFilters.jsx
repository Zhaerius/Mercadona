export function ArticleFilters({categories, onSelected, onChecked}) {

    const handleClick = () => {
        onSelected(document.querySelector(".form-select").value)
        onChecked(document.querySelector("#flexSwitchCheckDefault").checked)
    }

    return (
        <>
            <div id="filter" className="d-flex flex-column gap-3 bg-body-secondary p-3 rounded-2">

                <div className="fw-semibold">Filtrer : </div>
                <select className="form-select" aria-label="Default select example">
                    <option value="" placeholder="dsd">Tous</option>
                    {
                        categories.map(category => (
                            <option value={category.id} key={category.id}>
                                {category.name}
                            </option>
                        ))
                    }
                </select>

                <div className="form-check form-switch">
                    <input className="form-check-input" type="checkbox" role="switch" id="flexSwitchCheckDefault"/>
                    <label className="form-check-label" htmlFor="flexSwitchCheckDefault">En promotion</label>
                </div>

                <button className="btn btn-primary" onClick={handleClick}>
                    <span className="text-uppercase text-white fw-semibold">Valider</span>
                </button>
            </div>
        </>
    )
}