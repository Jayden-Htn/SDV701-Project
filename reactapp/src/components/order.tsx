import { useNavigate, useParams } from 'react-router-dom';
import styles from "./order.module.css";
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

const Order = () => {
  const navigate = useNavigate();
  const id = useParams()

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

  const [product, setProduct] = useState<product>(content)
  const [quantity, setQuantity] = useState<number>(1)
  const [customerName, setCustomerName] = useState<string>("")
  const [customerEmail, setCustomerEmail] = useState<string>("")
  const [customerPhone, setCustomerPhone] = useState<string>("")

  const handlePurchase =() => {
    window.alert("Purchase successful");
    navigate(`/product/${product?.id}`);
  }


  return (
    <div className={styles.container}>
      <div className={styles.bodyContainer}>
        <h2>Create Order</h2>
        <div className={styles.bodyBlock}>
          <div>
            <p><b>Item:</b> {product?.brand} {product?.name}</p>
            <p><b>Price per item:</b> ${product?.price} in stock</p>
            <div className={styles.textRow}>
              <label htmlFor="quantity"><b>Quantity:</b></label>
              <input type="number" id="quantity" name="quantity" value={quantity} onChange={(e) => setQuantity(Number(e.target.value))}></input>
            </div>
            <p><b>Order total:</b> ${quantity ? (product!.price * quantity!).toFixed(2) : ""}</p>
            
          </div>
          <div className={styles.aside}>
            <div className={styles.asideColumn}>
              <label htmlFor="fullname"><b>Full name:</b></label>
              <label htmlFor="email"><b>Email:</b></label>
              <label htmlFor="phone"><b>Phone: </b></label>
            </div>
            <div className={styles.asideColumn}> 
              <input type="text" id="fullname" name="fullname" value={customerName} onChange={(e) => setCustomerName(e.target.value)}></input>
              <input type="text" id="email" name="email" value={customerEmail} onChange={(e) => setCustomerEmail(e.target.value)}></input>
              <input type="text" id="phone" name="phone" value={customerPhone} onChange={(e) => setCustomerPhone(e.target.value)}></input>
            </div>
          </div>
        </div>
        <div className={styles.buttonBox}>
          <button 
            onClick={() => navigate(`/product/${product?.id}`)}
          >
            Cancel
          </button>
          <button 
            disabled={!quantity || !customerName || !customerEmail || !customerPhone}
            onClick={handlePurchase}
          >
            Purchase
          </button>
        </div>
      </div>
    </div>
  );
};

export default Order;