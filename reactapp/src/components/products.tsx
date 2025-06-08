import { useEffect, useState } from "react";
import { Link } from 'react-router-dom';
import styles from "./products.module.css";
import React from "react";

interface product {
  id: number,
  name: string,
  description: string,
  price: number,
  quantityAvailable: number,
  brand: string,
  brandId: number,
  type: string,
  photo: string | undefined
}

const Products = () => {
  const [content, setContent] = useState<product[]>();
  const [filter, setFilter] = useState<number>(0);
  const [filteredContent, setFilteredContent] = useState<product[]>();

  useEffect(() => {
    var content = [
      {
        id: 1,
        name: "Name",
        description: "Description description description description description description description description description description",
        price: 13.55,
        quantityAvailable: 5,
        brand: "Tooler",
        brandId: 1,
        type: "RideOn",
        photo: undefined
      },
      {
        id: 2,
        name: "Name2",
        description: "Description description description description description description description description description description",
        price: 11.55,
        quantityAvailable: 10,
        brand: "MowGo",
        brandId: 2,
        type: "RideOn",
        photo: undefined
      }
    ]
    setContent([...content, ...content, ...content, ...content]);
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
                <img src={product.photo} className={styles.photo}></img>
                <div className={styles.cardText}>
                  <Link to={`/product/${product?.id}`}>
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