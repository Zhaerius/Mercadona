export function Header({logo}) {
    return(
        <header className="p-3 text-bg-dark">
            <div className="container">
                <div className="d-flex flex-wrap align-items-center justify-content-center justify-content-lg-start">
                    <a href="/" className="d-flex align-items-center mb-2 mb-lg-0 text-white text-decoration-none">
                        <img alt="Vue logo" className="bi me-2" src={logo} height="45" />
                    </a>
                    <ul className="nav col-12 col-lg-auto me-lg-auto mb-2 justify-content-center mb-md-0">
                        <li><a className="nav-link px-2 text-white">Catalogue</a></li>
                    </ul>
                    <div className="text-end">
                        <i className="bi bi-facebook"></i>
                        <i className="bi bi-twitter-x"></i>
                        <i className="bi bi-instagram"></i>
                    </div>
                </div>
            </div>
        </header>
    );
}