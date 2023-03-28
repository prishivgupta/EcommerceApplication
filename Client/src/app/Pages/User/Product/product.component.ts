import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/Models/Product';
import { CartService } from 'src/app/Services/Cart/cart.service';
import { ProductService } from 'src/app/Services/Products/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent {

  constructor(private productService: ProductService, private cartService: CartService, private route: ActivatedRoute) {}

  product: Product = {
    productId: 0,
    productName: '',
    productDescription: '',
    productPrice: 0,
    productDiscountedPrice: 0,
    productQuantity: 0,
    rating: 0,
    productImages: '',
    categoryId: 0
  };

  cartItem: any = {
    cartId: 0,
    productId: 0,
    productQuantity: 1
  }

  orderQuantity = 1;

  getProductById(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.productService.getProductById(id).subscribe(product => {
      this.product.productId = product.productId,
      this.product.productName = product.productName,
      this.product.productDescription = product.productDescription,
      this.product.productPrice = product.productPrice,
      this.product.productDiscountedPrice = product.productDiscountedPrice,
      this.product.productImages = product.productImages,
      this.product.productQuantity = product.productQuantity,
      this.product.rating = product.rating,
      this.product.categoryId = product.categoryId
    });
  }

  decreaseQuantity(): void {
    if (this.orderQuantity > 1) 
    this.orderQuantity -= 1;
  }

  increaseQuantity(): void {
    if (this.orderQuantity < this.product.productQuantity) 
    this.orderQuantity += 1;
  }

  addToCart(productId: number): void {
    this.cartItem.cartId = Number(localStorage.getItem('cartId'))
    this.cartItem.productId = productId
    this.cartItem.productQuantity = this.orderQuantity
    this.cartService.addToCart(this.cartItem).subscribe();
  }

  ngOnInit(): void {
    this.getProductById();
  }

}
