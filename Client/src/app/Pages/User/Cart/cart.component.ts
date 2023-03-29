import { Component } from '@angular/core';
import { CartItem } from 'src/app/Models/CartItem';
import { CartService } from 'src/app/Services/Cart/cart.service';
import { ProductService } from 'src/app/Services/Products/product.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent {

  constructor(private toastr: ToastrService, private cartService: CartService) {}

  cartItems: CartItem[] = [];

  cartItem: any = {
    cartId: 0,
    productId: 0,
    productQuantity: 1
  }

  getImage(image: any): void {
    let images = JSON.parse("[" + image + "]")
    return images[1]
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
    this.cartService.addToCart(this.cartItem).subscribe(() => {
      this.getAllCartItems()
      this.toastr.success('Updated Cart Successfully')
    })
  }

  ngOnInit(): void {
    this.getAllCartItems();
  }

}
