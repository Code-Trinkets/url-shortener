import { neue } from "@/assets/fonts"

export default function Header() {
    return (
        <div className="header">
            <h1 className={neue.className}><span className={`bold`}>JSHORT</span> URL SHORTENER</h1>
        </div>
    )
}