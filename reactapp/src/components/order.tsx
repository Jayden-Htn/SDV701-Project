import { useNavigate, useParams } from 'react-router-dom';
import styles from "./order.module.css";
import React, { useEffect, useState } from "react";
import Product from "../models/Lawnmower";
import OrderModel from "../models/Order";
import Lawnmower from '../models/Lawnmower';
import productService from '../services/productService';
import orderService from '../services/orderService';

const Order = () => {
  const navigate = useNavigate();
  const { type, id } = useParams()
  const [product, setProduct] = useState<Product>()
  const [quantity, setQuantity] = useState<number>(1)
  const [customerName, setCustomerName] = useState<string>("")
  const [customerEmail, setCustomerEmail] = useState<string>("")
  const [customerPhone, setCustomerPhone] = useState<string>("")

  useEffect(() => {
    const getProduct = async () => {
      try {
        const res: Lawnmower = await productService.getAsync(Number(id), type!);
        setProduct(res);
      } catch (err) {
        console.error(err);
      }
    };

    getProduct();
  }, []);

  const handlePurchase = async () => {
    try {
      const orderObj = {
        id: 0,
        quantity: quantity,
        timeCreated: new Date(),
        itemPrice: product!.price,
        customerName: customerName,
        customerEmail: customerEmail,
        customerPhone: customerPhone,
        productId: product!.id,
        completed: false
      } as OrderModel;
      await orderService.addAsync(orderObj);
      window.alert("Purchase successful");
      navigate(`/product/${product?.type}/${product?.id}`);
    } catch (err) {
      console.error(err);
      window.alert("Error making purchase");
    }
  }


  return (
    <div className={styles.container}>
      <div className={styles.bodyContainer}>
        <h2>Create Order</h2>
        <div className={styles.bodyBlock}>
          <div>
            <p><b>Item:</b> {product?.brand?.name} {product?.name}</p>
            <p><b>Price per item:</b> ${product?.price} in stock</p>
            <div className={styles.textRow}>
              <label htmlFor="quantity"><b>Quantity:</b></label>
              <input type="number" id="quantity" name="quantity" value={quantity} onChange={(e) => setQuantity(Number(e.target.value))}></input>
            </div>
            <p><b>Order total:</b> ${quantity && product?.price ? (product!.price * quantity!).toFixed(2) : ""}</p>
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