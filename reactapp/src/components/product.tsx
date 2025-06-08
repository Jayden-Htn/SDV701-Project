import { useNavigate, useParams } from 'react-router-dom';
import styles from "./product.module.css";
import React, { useEffect, useState } from "react";

interface product {
  id: number,
  name: string,
  description: string,
  price: number,
  quantityAvailable: number,
  brand: string,
  brandId: number,
  type: string,
  photo: string | undefined,
  fuelDetails: string,
  weight: number,
  topSpeed: number
}

const Product = () => {
  const navigate = useNavigate();
  const id = useParams()
  const [product, setProduct] = useState<product>()

  useEffect(() => {
    var content = 
      {
        id: 1,
        name: "Name",
        description: "Description description description description description description description description description description",
        price: 13.55,
        quantityAvailable: 5,
        brand: "Tooler",
        brandId: 1,
        type: "RideOn",
        photo: undefined,
        fuelDetails: "5 litre tank, petrol",
        weight: 25,
        topSpeed: 15
      }
    setProduct(content);
  }, []);


  return (
    <div className={styles.container}>
      <div className={styles.bodyBlock}>
        <div className={styles.article}>
          <h2>{product?.brand} {product?.name}</h2>
          <div className={styles.textRow}>
            <p><b>${product?.price}</b></p>
            <p>{product?.quantityAvailable} in stock</p>
            <button 
              disabled={product?.quantityAvailable == 0}
              onClick={() => navigate(`/order/${product?.id}`)}
            >
              Purchase
            </button>
          </div>
          <p>{product?.description}</p>
          <p><b>Brand:</b> {product?.brand}</p>
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
          <img src={product?.photo} className={styles.photo}></img>
        </div>
      </div>
    </div>
  );
};

export default Product;