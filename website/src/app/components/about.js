import { neue } from "@/assets/fonts";

export default function About() {
    return (
        <div className="divAbout">
            <h1 className={`${neue.className}`}>About This Project</h1>
            <p className={`${neue.className}`}>
            Do you have a URL that's just too long to send to someone? Perhaps you want to 
            share a cool link on Twitter, but the link is way too long and takes up too many 
            of your precious characters. If this fits your description, then the JShort URL 
            shortener is just right for you! JShort converts your long URL into a short compact URL 
            that you can send to your friends easily.
            </p>
            <br />
            <p className={`${neue.className}`}>
                Made by Jason Su and designed by Rizmari Arrogante.
            </p>
        </div>
    )
}