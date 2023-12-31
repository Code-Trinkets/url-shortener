'use client';
import { Button } from "react-bootstrap";
import { Image } from "react-bootstrap";
import { ToastContainer, toast } from 'react-toastify';
import { useState } from "react";
import settings from "../appsettings.json";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCopy, faCheck } from "@fortawesome/free-solid-svg-icons";
import CopySVGImage from "../../assets/copy.svg";
import CheckSVGImage from "../../assets/check.svg";
import { neue } from "@/assets/fonts";

export default function GenerateURL() {
    // Stateful variables
    const [outputField, setOutputField] = useState("Your short URL will appear here.");
    const [outputImageSrc, setOutputImageSrc] = useState(CopySVGImage.src);
    const [btnCopyDisabled, setBtnCopyDisabled] = useState(true);
    const [copied, setCopied] = useState(false);

    // Constants
    const inputField = "inputUrl";

    async function handleSubmit(event) {
        //  Don't reload the page
        event.preventDefault();

        // Parsing the form data.
        var formData = new FormData(event.target);
        
        let longUrl;
        for (const [key, value] of formData.entries())
            if (key == inputField) longUrl = value;
        
        let shortUrl = await getShortenedUrl(longUrl);

        if (shortUrl === null) {
            toast.error("There was an internal error.");
            return;
        }

        setOutputField(shortUrl);
        setBtnCopyDisabled(false);
    }

    async function getShortenedUrl(longUrl) {
        const url = settings.APIUrl + "api/url";

        let result;
        try {
            result = await fetch(url, {
                method: 'POST',
                body: JSON.stringify({
                    longURL: longUrl
                }),
                headers: {
                    'Content-type': 'application/json; charset=UTF-8'
                }
            });
        }
        catch(err) {
            console.log(err);
            return null;
        }
        let response = await result.json();
        
        if (response.statusCode == 201)
            return response.data;
        
        return null;
    }

    function handleCopy(event) {
        // Don't reload the page.
        event.preventDefault();

        // Copy data to the clipboard.
        navigator.clipboard.writeText(outputField);
        setCopied(true);
        setTimeout(() => setCopied(false), 6000);

        // Toaster
        toast.success("Copied!", {
            position: toast.POSITION.TOP_RIGHT
        });

        setOutputImageSrc(CheckSVGImage.src);

        setTimeout(() => {
            setOutputImageSrc(CopySVGImage.src)
        }, 1000);
    }
    return(
        <div className="divGenerateUrl">
            <h1 className={`${neue.className}`}>Shorten a URL</h1>
            <form method="post" onSubmit={handleSubmit} className="formGenerateUrl">
                <input type="text" name={inputField}/>
                <Button variant="secondary" className={`btnSubmit ${neue.className}`} type="submit">Shorten</Button>
            </form>
            <br />
            <form onSubmit={handleCopy}>
                <input type="text" disabled value={outputField}/>
                <Button className="btnCopy" disabled={btnCopyDisabled} type="submit">
                    {
                        !copied &&
                        <FontAwesomeIcon
                            className={`iconCopy`}
                            icon={faCopy}
                            style={{ fontSize: 22 }}
                        />
                    }
                    {
                        copied &&
                        <FontAwesomeIcon
                            className={`iconCopy`}
                            icon={faCheck}
                            style={{ fontSize: 22 }}
                        />
                    }
                </Button>
            </form>
        </div>
    )
}