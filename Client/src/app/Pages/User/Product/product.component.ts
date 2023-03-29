import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from 'src/app/Models/Product';
import { CartService } from 'src/app/Services/Cart/cart.service';
import { ProductService } from 'src/app/Services/Products/product.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})

export class ProductComponent {
  
  constructor(private toastr: ToastrService, private productService: ProductService, private cartService: CartService, private route: ActivatedRoute) {}

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

  images = [];

  getImage1(image: any): void {
    this.getImages(image)
    let images = JSON.parse("[" + image + "]")
    return images[1]
  }

  getImages(image: any): void {
    let images = JSON.parse("[" + image + "]")
    this.images = images;
  }

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
    this.cartService.addToCart(this.cartItem).subscribe(() => this.toastr.success('Added To Cart Successfully'));
  }

  ngOnInit(): void {
    this.getProductById();
  }

}
