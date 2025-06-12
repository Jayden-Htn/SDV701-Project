export default interface Product {
  id: number,
  quantity: number,
  timeCreated: Date,
  itemPrice: number,
  customerName: string,
  customerEmail: string,
  customerPhone: string,
  productId: number,
  completed: boolean,
}