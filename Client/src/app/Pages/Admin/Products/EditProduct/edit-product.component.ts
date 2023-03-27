import { Component } from '@angular/core';
import { ProductService } from 'src/app/Services/Products/product.service';
import { Location } from '@angular/common';
import { Product } from 'src/app/Models/Product';
import { CategoryService } from 'src/app/Services/Categories/category.service';
import { Category } from 'src/app/Models/Category';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent {

  constructor(private productService: ProductService, private categoryService: CategoryService, private location: Location, private route: ActivatedRoute) {}

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

  categories: Category[] = [];

  productImages: string[] = [];

  goBack(): void {
    this.location.back();
  }

  editProduct(product: Product): void {
    this.productService.updateProduct(product).subscribe(() => this.goBack());
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

  getAllCategories(): void {
    this.categoryService.getAllCategories().subscribe(categories => this.categories = categories);
  }

  ngOnInit(): void {
    this.getProductById();
    this.getAllCategories();
  }

}
