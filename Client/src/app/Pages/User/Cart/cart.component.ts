import { Component } from '@angular/core';
import { CartItem } from 'src/app/Models/CartItem';
import { CartService } from 'src/app/Services/Cart/cart.service';
import { ProductService } from 'src/app/Services/Products/product.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent {

  constructor(private cartService: CartService) {}

  cartItems: CartItem[] = [];

  cartItem: any = {
    cartId: 0,
    productId: 0,
    productQuantity: 1
  }

  getAllCartItems(): void {
    this.cartService.getAllCartItems(Number(localStorage.getItem('cartId'))).subscribe(cartItems => this.cartItems = cartItems);
  }

  clearCart(): void {
    this.cartService.clearCart(Number(localStorage.getItem('cartId'))).subscribe(() => this.getAllCartItems())
  }

  updateCart(productId: number, productQuantity: number): void {
    this.cartItem.cartId = Number(localStorage.getItem('cartId'))
    this.cartItem.productId = productId
    this.cartItem.productQuantity = productQuantity
    this.cartService.addToCart(this.cartItem).subscribe(() => this.getAllCartItems())
  }

  ngOnInit(): void {
    this.getAllCartItems();
  }

}
