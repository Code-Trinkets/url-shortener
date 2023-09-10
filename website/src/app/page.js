'use client';

import GenerateURL from "./components/generate-url";
import Header from "./components/header";
import About from "./components/about";
import "@fortawesome/fontawesome-svg-core/styles.css"; 
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faSpinner } from "@fortawesome/free-solid-svg-icons";
import { useState, useEffect } from "react";
import settings from './appsettings.json';

export default function Home() {
  const [loading, setLoading] = useState(true);
  // Pinging the API to wake it up.
  useEffect(() => {
    // Helpers
    const url = `${settings.APIUrl}api/url/${settings.identifier}`;
    console.log(url);

    fetch(url, {
        method: 'GET',
        headers: {
            'Content-type': 'application/json; charset=UTF-8'
        }
    })
    .catch(err => {
        console.log(err);
        toast.error("An internal error occurred.");
        return;
    })
    .finally(() => {
      setLoading(false);
    });
}, []);
  return (
    <main className={`divMain`}>
      {
        loading &&
        <div className="loadingDiv">
          <h1 className="flex h1Wakeup">
          <FontAwesomeIcon
            pulse
            className={`iconSpinner`}
            icon={faSpinner}
            style={{ fontSize: 25 }}
          />
            Waking up API...
          </h1>
        </div>
      }
      {
        !loading &&
        <>
          <Header />
          <GenerateURL />
          <About />
        </>
      }
      <br />
    </main>
  )
}
