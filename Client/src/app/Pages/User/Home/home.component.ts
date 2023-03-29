import { Component } from '@angular/core';
import { Product } from 'src/app/Models/Product';
import { AuthService } from 'src/app/Services/Auth/auth.service';
import { CartService } from 'src/app/Services/Cart/cart.service';
import { ProductService } from 'src/app/Services/Products/product.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  constructor(private toastr: ToastrService, private productService: ProductService, private cartService: CartService, private authService: AuthService) {}

  products: Product[] = [];
  id?: number;

  search = "";

  searchProducts(): void {
    this.getAllProducts()
  }

  cartItem: any = {
    cartId: 0,
    productId: 0,
    productQuantity: 1
  }

  getImage(image: any): void {
    let images = JSON.parse("[" + image + "]")
    return images[1]
  }

  logout(): void {
    this.authService.logout();
  }

  isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }

  isLoggedOut(): boolean {
    return !this.authService.isLoggedIn();
  }

  getAllProducts(): void {
    this.productService.getAllProducts(1, this.search).subscribe(products => this.products = products);
  }

  addToCart(productId: number): void {
    this.cartItem.cartId = Number(localStorage.getItem('cartId'))
    this.cartItem.productId = productId
    this.cartService.addToCart(this.cartItem).subscribe(() => this.toastr.success('Added To Cart Successfully'));
  }

  ngOnInit(): void {
    this.getAllProducts();
  }
}
