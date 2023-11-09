export function Header({logo}) {
    return (
        <header>
            <div className="px-3 py-2 bg-dark">
                <div className="container">
                    <div
                        className="d-flex flex-wrap align-items-center justify-content-center justify-content-lg-start">
                        <a href="/"
                           className="d-flex align-items-center my-2 my-lg-0 me-lg-auto text-white text-decoration-none">
                            <img alt="Vue logo" className="bi me-2" src={logo} height="45"/>
                        </a>

                        <ul className="nav col-12 col-lg-auto my-2 justify-content-center my-md-0 text-white gap-3">
                            <li>
                                <i className="bi bi-facebook"></i>
                            </li>
                            <li>
                                <i className="bi bi-twitter-x"></i>
                            </li>
                            <li>
                                <i className="bi bi-instagram"></i>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </header>
    );
}