import './App.css'
import { Routes, Route, Link } from "react-router-dom";
import Products from "./components/products";
import Product from "./components/product";

function App() {
  return (
    <>
      <nav>
        <h1>GrassMaster's Lawnmowers</h1>
        <Link to={`/Products`}>
          <p>Home</p>
        </Link>
      </nav>
      <Routes>
        <Route path="/" element={<Products />} />
        <Route path="/Products" element={<Products />} />
        <Route path="/product/:id" element={<Product/>} />
      </Routes>  
    </>
  )
}

export default App
