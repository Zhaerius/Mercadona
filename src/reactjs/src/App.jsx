import {useState} from 'react'
import {Header} from "./Components/Header.jsx"
import mercaLogo from './assets/mercadona.svg'
import {ArticleCard} from "./Components/ArticleCard.jsx"
import {Articles} from "./Components/Articles.jsx";

function App() {
    const [count, setCount] = useState(0)

    return (
        <>
            <Header logo={mercaLogo}/>
            <main>
                <div className="container">
                    <Articles/>
                </div>
            </main>
        </>
    )
}

export default App
