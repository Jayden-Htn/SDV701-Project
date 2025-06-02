import './App.css'
import { Routes, Route } from "react-router-dom";
import Products from "./components/products";
import Product from "./components/product";

function App() {
  return (
    <>
      <nav>
        <h1>GrassMaster's Lawnmowers</h1>
      </nav>
      <Routes>
        <Route path="/" element={<Products />} />
        <Route path="/product/id" element={<Product/>} />
      </Routes>  
    </>
  )
}

export default App
