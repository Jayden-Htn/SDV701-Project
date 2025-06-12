import { useEffect, useState } from "react";
import { Link } from 'react-router-dom';
import styles from "./products.module.css";
import React from "react";
import Lawnmower from "../models/Lawnmower";
import productService from "../services/productService"

const Products = () => {
  const [content, setContent] = useState<Lawnmower[]>();
  const [filter, setFilter] = useState<number>(0);
  const [filteredContent, setFilteredContent] = useState<Lawnmower[]>();

  useEffect(() => {
    const getProducts = async () => {
      try {
        const res: Lawnmower[] = await productService.listAsync();
        setContent(res);
      } catch (err) {
        console.error(err);
      }
    };

    getProducts();
  }, []);

  useEffect(() => {
    if (filter == 0) {
      setFilteredContent(content);
    } else {
      var filteredItems = content?.filter(x => x.brandId == filter);
      setFilteredContent(filteredItems);
    }
    
  }, [filter, content])

  const filterChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
    setFilter(Number(event.target.value))
  }
  

  return (
    <div className={styles.container}>
      <div className={styles.textRow}>
        <h2>Products</h2>
        <select name="cars" id="cars" value={filter} onChange={(e) => filterChange(e)}>
          <option value="0">All</option>
          <option value="1">Tooler</option>
          <option value="2">MowGo</option>
        </select>
      </div>
      
      <div className={styles.shopContainer}>
        {
          Array.isArray(content) ? (
            filteredContent?.map((product, i) => (
              <div key={i} className={styles.itemCard}>
                <img src={'data:image/jpeg;base64,'+product.photo} className={styles.photo}></img>
                <div className={styles.cardText}>
                  <Link to={`/product/${product?.type}/${product?.id}`}>
                    <h3 className={styles.textItem}>{product?.brand?.name} {product.name}</h3>
                  </Link>
                  <div className={styles.textRow}>
                    <p className={styles.textItem}><b>Price: ${product.price}</b></p>
                    <p className={styles.textItem}>Quantity: {product.quantityInStock}</p>
                  </div>
                  <p className={`${styles.textItem} ${styles.description}`}>{product.description}</p>
                  <div className={styles.textRow}>
                    <p className={styles.textItem}>Category: {product.type}</p>
                    <p className={styles.textItem}>Brand: {product?.brand?.name}</p>
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