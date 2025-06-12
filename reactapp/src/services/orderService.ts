import axios from "axios";
import Order from "../models/Order.js"

const API_URL = "http://localhost:5243/api/order/";

// Create order
const addAsync = async (order: Order) => {
  return await axios.post(API_URL, order);
};

const OrderService = {
  addAsync
};

export default OrderService;