import './globals.css'
// add bootstrap css 
import 'bootstrap/dist/css/bootstrap.css'
import 'react-toastify/dist/ReactToastify.css';
import { ToastContainer } from 'react-toastify';


export const metadata = {
  title: 'JShort URL Shortener',
  description: 'A URL shortener made by Jason Su.',
  other: {
    'google-adsense-account': 'ca-pub-2550162082933996'
  }
}

export default function RootLayout({ children }) {
  return (
    <html lang="en">
      <body>
        {children}
        <ToastContainer />
      </body>
    </html>
  )
}
