'use client';
import { Button } from "react-bootstrap";
import { Image } from "react-bootstrap";
import { ToastContainer, toast } from 'react-toastify';
import { useState } from "react";
import CopySVGImage from "../../assets/copy.svg";
import CheckSVGImage from "../../assets/check.svg";

export default function GenerateURL() {
    // Stateful variables
    const [outputField, setOutputField] = useState("Your short URL will appear here.");
    const [outputImageSrc, setOutputImageSrc] = useState(CopySVGImage.src);
    const [btnCopyDisabled, setBtnCopyDisabled] = useState(true);

    // Constants
    const inputField = "inputUrl";

    function handleSubmit(event) {
        //  Don't reload the page
        event.preventDefault();

        // Parsing the form data.
        var formData = new FormData(event.target);
        
        for (const [key, value] of formData.entries())
            if (key == inputField) console.log(value);

        console.log(CopySVGImage);
    }

    function handleCopy(event) {
        // Don't reload the page.
        event.preventDefault();

        // Copy data to the clipboard.
        navigator.clipboard.writeText(outputField);

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
            <h1>Shorten a URL</h1>
            <form method="post" onSubmit={handleSubmit} className="formGenerateUrl">
                <input type="text" name={inputField}/>
                <Button variant="secondary" className="btnSubmit" type="submit">Shorten</Button>
            </form>
            <br />
            <form onSubmit={handleCopy}>
                <input type="text" disabled value={outputField}/>
                <Button variant="secondary" className="btnCopy" disabled={btnCopyDisabled} type="submit">
                    <Image src={outputImageSrc} width={30} height={30}/>
                </Button>
            </form>
        </div>
    )
}