import { useNavigate, useParams } from 'react-router-dom';
import styles from "./product.module.css";
import React, { useEffect, useState } from "react";
import Lawnmower from "../models/Lawnmower";
import productService from "../services/productService"

const Product = () => {
  const navigate = useNavigate();
  const { type, id } = useParams()
  const [product, setProduct] = useState<Lawnmower>()

  useEffect(() => {
    const getProduct = async () => {
      try {
        const res: Lawnmower = await productService.getAsync(Number(id), type!);
        console.log(res)
        setProduct(res);
      } catch (err) {
        console.error(err);
      }
    };

    getProduct();
  }, []);


  return (
    <div className={styles.container}>
      <div className={styles.bodyBlock}>
        <div className={styles.article}>
          <h2>{product?.brand?.name} {product?.name}</h2>
          <div className={styles.textRow}>
            <p><b>${product?.price}</b></p>
            <p>{product?.quantityInStock} in stock</p>
            <button 
              disabled={product?.quantityInStock == 0}
              onClick={() => navigate(`/order/${product?.type}/${product?.id}`)}
            >
              Purchase
            </button>
          </div>
          <p>{product?.description}</p>
          <p><b>Brand:</b> {product?.brand?.name}</p>
          <p><b>Category:</b> {product?.type}</p>
          <p><b>Fuel details:</b> {product?.fuelDetails}</p>
          {
            product?.type == "Push" ? 
              <p><b>Weight:</b> {product?.weight} kg</p> 
              :
              <p><b>Top speed:</b> {product?.topSpeed} km/h</p>
          } 
        </div>
        <div>
          {
            product?.photo ? 
            <img src={'data:image/jpeg;base64,'+product?.photo} className={styles.photo}></img>
            : <></>
          }
          
        </div>
      </div>
    </div>
  );
};

export default Product;