import { Component } from '@angular/core';
import { Product } from 'src/app/Models/Product';
import { CartService } from 'src/app/Services/Cart/cart.service';
import { ProductService } from 'src/app/Services/Products/product.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  constructor(private productService: ProductService, private cartService: CartService) {}

  products: Product[] = [];
  id?: number;

  cartItem: any = {
    cartId: 0,
    productId: 0,
    productQuantity: 1
  }
  

  getAllProducts(): void {
    this.productService.getAllProducts().subscribe(products => this.products = products);
  }

  addToCart(productId: number): void {
    this.cartItem.cartId = Number(localStorage.getItem('cartId'))
    this.cartItem.productId = productId
    this.cartService.addToCart(this.cartItem).subscribe();
  }

  ngOnInit(): void {
    this.getAllProducts();
  }
}
