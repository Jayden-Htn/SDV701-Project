import './App.css'
import { Routes, Route, Link } from "react-router-dom";
import Products from "./components/products";
import Product from "./components/product";
import Order from "./components/order";

function App() {
  return (
    <>
      <nav>
        <h1>GrassMaster's Lawnmowers</h1>
        <Link to={`/products`}>
          <p>Home</p>
        </Link>
      </nav>
      <article>
        <Routes>
          <Route path="/" element={<Products />} />
          <Route path="/products" element={<Products />} />
          <Route path="/product/:type/:id" element={<Product/>} />
          <Route path="/order/:type/:id" element={<Order/>} />
        </Routes>  
      </article>
      
    </>
  )
}

export default App
