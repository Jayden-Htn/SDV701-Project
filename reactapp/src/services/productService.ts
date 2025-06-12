import axios from "axios";
import Lawnmower from "../models/Lawnmower";

const API_URL = "http://localhost:5243/api/lawnmower/";

// Get item
const getAsync = async (id: number, type: string) => {
  const res = await axios.get(API_URL+id);
  console.log(res)
  const lawnmower: Lawnmower = res.data;
  return lawnmower;
};

// List
const listAsync = async () => {
  var res = await axios.get(API_URL + "list/0"); // All brands
  const lawnmowers: Lawnmower[] = res.data;
  return lawnmowers;
};

const UserService = {
  getAsync,
  listAsync
};

export default UserService;