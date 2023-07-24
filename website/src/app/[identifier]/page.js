'use client';

import { useEffect, useState } from "react"
import settings from "../appsettings.json";
import { toast } from "react-toastify";
import LoadingGIF from "../../assets/loading.gif";
import { Image } from "react-bootstrap";

export default function RedirectToURL({ params }) {
    const [redirecting, setRedirecting] = useState(true);
    useEffect(() => {
        // Helpers
        async function getLongUrl(identifier) {
            const url = `${settings.APIUrl}api/url/${identifier}`;
            console.log(url);

            await fetch(url, {
                method: 'GET',
                headers: {
                    'Content-type': 'application/json; charset=UTF-8'
                }
            })
            .then(response => response.json())
            .then(response => {
                if (response.statusCode == 200)
                    window.location.replace(response.data);
                else {
                    setRedirecting(false);
                }
            })
            .catch(err => {
                console.log(err);
                toast.error("An internal error occurred.");
                return;
            });
        }
        
        getLongUrl(params.identifier);
    }, []);

    if (redirecting) {
        return (
            <div className="divRedirect">
                <h1 className="h1Redirect">Redirecting...</h1>
                <Image src={LoadingGIF.src} width={30} height={30}/>
            </div>
        )
    }
    else {
        return (
            <div className="divRedirect">
                <h1 className="h1Redirect">Oh no!</h1>
                <p className="pRedirectFail">
                    It looks like that URL is invalid. Make sure that you have a URL that was made using this website!
                </p>
            </div>
        )
    }
    
}