import { useEffect, useState } from "react";
import { Link } from 'react-router-dom';
import styles from "./products.module.css";

const Products = () => {
  const [content, setContent] = useState<object>();

  useEffect(() => {
    setContent([
      {
        id: 1,
        name: "Name",
        description: "Description",
        price: 13.55,
        quantityAvailable: 5,
        brand: "Tooler",
        type: "RideOn"
      },
      {
        id: 2,
        name: "Name2",
        description: "Description2",
        price: 11.55,
        quantityAvailable: 10,
        brand: "Tooler",
        type: "RideOn"
      }
    ])
  }, []);
  

  return (
    <div className={styles.container}>
      <h2>Products</h2>
      <div className={styles.shopContainer}>
        {
          Array.isArray(content) ? (
            content.map((product, i) => (
              <div key={i} className={styles.itemCard}>
                <Link to={`/Product/${product?.id}`}>
                  <h3>{product.name}</h3>
                </Link>
                <p>{product.description}</p>
                <p>Price: {product.price}</p>
                <p>Quantity: {product.quantityAvailable}</p>
              </div>
            ))
          ) : (
            <p>No items</p>
          )
        }
      </div>
    </div>
  );
};

export default Products;