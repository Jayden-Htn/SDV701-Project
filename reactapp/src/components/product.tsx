import { useState } from "react";
import { useNavigate } from 'react-router-dom';
import styles from "./product.module.css";

const Product = () => {
  const navigate = useNavigate();


  return (
    <div className={styles.container}>
      <h3>Product Item</h3>
    </div>
  );
};

export default Product;