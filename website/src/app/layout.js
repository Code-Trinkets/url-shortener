import './globals.css'
// add bootstrap css 
import 'bootstrap/dist/css/bootstrap.css'
import 'react-toastify/dist/ReactToastify.css';
import { ToastContainer } from 'react-toastify';

export const metadata = {
  title: 'JShort URL Shortener',
  description: 'A URL shortener made by Jason Su.',
}

export default function RootLayout({ children }) {
  return (
    <html lang="en">
      <head>
        <script async src="https://pagead2.googlesyndication.com/pagead/js/adsbygoogle.js?client=ca-pub-2550162082933996" crossorigin="anonymous"></script>
      </head>
      <body>
        {children}
        <ToastContainer />
      </body>
    </html>
  )
}
