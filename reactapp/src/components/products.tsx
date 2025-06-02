import { useEffect, useState } from "react";
import { Link } from 'react-router-dom';
import styles from "./products.module.css";

const Products = () => {
  const [content, setContent] = useState<object>();

  useEffect(() => {
    var content = [
      {
        id: 1,
        name: "Name",
        description: "Description description description description description description description description description description",
        price: 13.55,
        quantityAvailable: 5,
        brand: "Tooler",
        type: "RideOn"
      },
      {
        id: 2,
        name: "Name2",
        description: "Description description description description description description description description description description",
        price: 11.55,
        quantityAvailable: 10,
        brand: "MowGo",
        type: "RideOn"
      }
    ]
    setContent([...content, ...content, ...content, ...content]);
  }, []);
  

  return (
    <div className={styles.container}>
      <h2>Products</h2>
      <div className={styles.shopContainer}>
        {
          Array.isArray(content) ? (
            content.map((product, i) => (
              <div key={i} className={styles.itemCard}>
                <img src={product.photo} className={styles.photo}></img>
                <div className={styles.cardText}>
                  <Link to={`/Product/${product?.id}`}>
                    <h3 className={styles.textItem}>{product.brand} {product.name}</h3>
                  </Link>
                  <div className={styles.textRow}>
                    <p className={styles.textItem}><b>Price: ${product.price}</b></p>
                    <p className={styles.textItem}>Quantity: {product.quantityAvailable}</p>
                  </div>
                  <p className={styles.textItem}>{product.description}</p>
                  <div className={styles.textRow}>
                    <p className={styles.textItem}>Category: {product.type}</p>
                    <p className={styles.textItem}>Brand: {product.brand}</p>
                  </div>
                  
                </div>
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