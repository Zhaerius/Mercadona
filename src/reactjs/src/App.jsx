import {useState} from 'react'
import {Header} from "./Components/Header.jsx"
import mercaLogo from './assets/mercadona.svg'
import {Articles} from "./Components/Articles.jsx";
import {Hero} from "./Components/Hero.jsx";

function App() {
    const [count, setCount] = useState(0)

    return (
        <>
            <Header logo={mercaLogo}/>
            <Hero />
            <div className="divider"></div>
            <main>
                <div className="container">
                    <Articles/>
                </div>
            </main>
        </>
    )
}

export default App
