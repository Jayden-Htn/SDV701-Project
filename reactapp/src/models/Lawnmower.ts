import Brand from './Brand';

export default interface Lawnmower {
  id: number,
  name: string,
  description: string,
  price: number,
  quantityInStock: number,
  brand: Brand,
  brandId: number,
  type: string,
  photo?: number[],
  fuelDetails: string,
  weight?: number,
  topSpeed: number
}