import { Cart } from "./Cart";
import { Product } from "./Product";

export interface CartItem {
    id: number,
    cartId: number,
    cart: Cart,
    productId: number,
    product: Product,
    productQuantity: number
}