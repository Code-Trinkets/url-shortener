import GenerateURL from "./components/generate-url";
import Header from "./components/header";
import About from "./components/about";

export default function Home() {
  return (
    <main>
      <Header />
      <GenerateURL />
      <About />
    </main>
  )
}
